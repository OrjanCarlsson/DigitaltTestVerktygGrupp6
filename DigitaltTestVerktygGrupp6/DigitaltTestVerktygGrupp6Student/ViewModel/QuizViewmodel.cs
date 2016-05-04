using DigitaltTestVerktygGrupp6Student.Database;
using DigitaltTestVerktygGrupp6Student.Model;
using DigitaltTestVerktygGrupp6Student.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.ViewModel
{
    class QuizViewmodel : INotifyPropertyChanged
    {
        public dbStudents ActiveStudent { get; set; }
        public List<dbQuizs> Quizes { get; set; }
        public dbQuizs SelectedQuiz { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
        public Question ActiveQuestion { get; set; }
        public Frame ContentFrame { get; set; }
        public Alternative SelectedAlternative { get; set; }
        public int Score { get; set; } = 0;
        public int CorrectAnswers { get; set; } = 0;
        public int TotalScore { get; set; }
        public static int MultiCorrectAnswers = 0;
        private Timer timer;
        public event Action NextQuestionEvent;

        public string DisplayTimer
        {
            get
            {
                return timer.Minutes + " : " + timer.Seconds;
            }
        }

        private Repository repo;
        public ButtonCommand ButtonCommand { get; }
        private static QuizViewmodel instance;
        private int questionIndex = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public static QuizViewmodel Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuizViewmodel();
                return instance;
            }
        }

        private QuizViewmodel()
        {
            repo = new Repository();
            Questions = new ObservableCollection<Question>();
            ButtonCommand = new ButtonCommand();
            ButtonCommand.Call += SwitchCommand;
        }

        internal void SelectionSetup(dbStudents student)
        {
            Quizes = repo.GetQuizes(ActiveStudent = student);
        }

        internal void QuizSetup()
        {
            repo.GetQuestions(SelectedQuiz).ForEach(Questions.Add);
            ActiveQuestion = Questions.First();
            foreach (var question in Questions)
            {
                TotalScore += question.Points;
            }
            timer = new Timer(SelectedQuiz.TimeLimit);
            timer.TimeOver += ShowResult;
            timer.Start();
        }

        private void SwitchCommand(string parameter)
        {
            switch (parameter)
            {
                case "NextQuestion":
                    NextQuestion();
                    break;
            }
        }

        private void NextQuestion()
        {
            if (ActiveQuestion.IsAnswered())
            {
                if (ActiveQuestion.AnswerCorrect())
                {
                    Score += ActiveQuestion.Points;
                    CorrectAnswers++;
                }
                if (Questions.IndexOf(ActiveQuestion) == Questions.Count - 1)
                    ShowResult();
                else
                {
                    ActiveQuestion = Questions[questionIndex++];
                    OnPropertyChanged("ActiveQuestion");
                    NextQuestionEvent.Invoke();
                }
            }
            else
            {
                MessageBox.Show("Välj ett svar!");
            }
        }

        public void ShowResult()
        {
            timer.Stop();
            ContentFrame.Navigate(new Results());
        }

        public void NavigateTo(Page page)
        {
            ContentFrame.Navigate(page);
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
