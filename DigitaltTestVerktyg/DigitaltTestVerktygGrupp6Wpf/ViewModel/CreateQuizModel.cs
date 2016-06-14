using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DigitaltTestVerktygGrupp6Wpf.ViewModel
{
    class CreateQuizModel : INotifyPropertyChanged
    {
        public Frame ContentFrame { get; set; }
        private static CreateQuizModel staticModel;

        public event PropertyChangedEventHandler PropertyChanged;

        // public dbQuestion Questions { get; set; }
        public ObservableCollection<dbQuiz> quizList { get; set; }
        public ObservableCollection<dbQuestion> questionList { get; set; }
        public ObservableCollection<dbAlternative> alternativeList { get; set; }

        private dbQuestion selectedQuestion;
       // private Alternative selectedAlternative;
        
        public dbQuestion SelectedQuestion
        {
            get { return selectedQuestion; }
            set { selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
            
        }

        public CreateQuizModel()
        {
            
            questionList = new ObservableCollection<dbQuestion>();
            alternativeList = new ObservableCollection<dbAlternative>();
            quizList = new ObservableCollection<dbQuiz>();
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public void NavigateTo(Page page)
        {
            ContentFrame.Navigate(page);
            // Questions = new dbQuestion

        }

        public static CreateQuizModel StaticModel
        {
            get
            {
                if (staticModel == null)
                    staticModel = new CreateQuizModel();
                return staticModel;
            }
        }
    }
}
