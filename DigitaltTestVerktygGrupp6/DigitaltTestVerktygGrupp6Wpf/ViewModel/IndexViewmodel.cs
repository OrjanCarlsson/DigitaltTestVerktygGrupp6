using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.ViewModel
{
    class IndexViewmodel
    {
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<dbQuiz> Quizzes { get; set; }
        public dbQuiz ActiveSendQuiz { get; set; }
        private Repository repo;
        public ButtonCommand ButtonCommand { get; }

        public IndexViewmodel()
        {
            repo = new Repository();
            ButtonCommand = new ButtonCommand();
            ButtonCommand.Call += SwitchCommand;
            Quizzes = new ObservableCollection<dbQuiz>();
            repo.QuizsList().ForEach(Quizzes.Add);
            Students = new ObservableCollection<Student>();

            foreach (var dbstudent in repo.StudentsList())
            {
                Students.Add(new Student(dbstudent));      
            }
        }

        private void SwitchCommand(string obj)
        {
            Console.WriteLine("this happens");
            if (obj.Equals("Send"))
                SendQuiz();
        }

        private void SendQuiz()
        {
            
        }
    }
}
