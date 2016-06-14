using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.ViewModel
{
    class IndexViewmodel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; }
        private List<Student> students;
        public ObservableCollection<dbQuiz> Quizzes { get; set; }
        private dbQuiz sendoutQuiz;

        public dbQuiz SendoutQuiz
        {
            get { return sendoutQuiz; }
            set
            {
                sendoutQuiz = value;
                Students.Clear();
                repo.FreeStudentQuizList(sendoutQuiz.dbQuizId, students).ForEach(Students.Add);
            }
        }

        public ObservableCollection<Student> SendoutList { get; set; }
        public dbQuiz ActiveSendQuiz { get; set; }
        private Repository repo;

        public event PropertyChangedEventHandler PropertyChanged;

        public ButtonCommand ButtonCommand { get; }

        public IndexViewmodel()
        {
            repo = new Repository();
            ButtonCommand = new ButtonCommand();
            ButtonCommand.Call += SwitchCommand;
            Quizzes = new ObservableCollection<dbQuiz>();
            Students = new ObservableCollection<Student>();
            SendoutList = new ObservableCollection<Student>();
            students = new List<Student>();
            repo.QuizsList().ForEach(Quizzes.Add);
            foreach (var dbstudent in repo.StudentsList())
            {
                students.Add(new Student(dbstudent));
            }
        }

        private void SwitchCommand(string parameter)
        {
            if (parameter.Equals("Sendout"))
                SendoutSetup();
            else if (parameter.Equals("Send"))
                Send();
            else if (parameter.Equals("Cancel"))
                SendoutList.Clear();
        }

        private void Send()
        {
            repo.SaveStudentQuiz(SendoutList, SendoutQuiz);
            SendoutList.Clear();
        }

        private void SendoutSetup()
        {
            OnPropertyChanged("SendoutQuiz");
            foreach (var student in Students)
            {
                if (student.SendTo == true)
                    SendoutList.Add(student);
            }
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
