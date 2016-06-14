using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Model;
using DigitaltTestVerktygGrupp6Wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitaltTestVerktygGrupp6Wpf.Views
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        
        CreateQuizModel viewModel;
        private IndexViewmodel ivm = new IndexViewmodel();
        private Repository repo = new Repository();
       
        public Index()
        {
            InitializeComponent();
            update();
            viewModel = CreateQuizModel.StaticModel;
            DataContext = ivm;
            // FrameCreateQuiz.NavigationService.GoBack();
            //viewModel.ContentFrame = FrameCreateQuiz;
            //viewModel.NavigateTo(new CreateQuiz());
        }

        public void update()
        {
            ExamListView.ItemsSource = repo.QuizsList();
            cbxQuizzes.ItemsSource = repo.QuizsList();
            UserListView.ItemsSource = repo.StudentsList();
            StatisticsListView.ItemsSource = repo.StudentQuizzesList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StatisticsListView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("student.FirstName", ListSortDirection.Descending));

        }
        private void DelUserBtn_Click(object sender, RoutedEventArgs e)
        {
            dbStudent delstu = UserListView.SelectedItem as dbStudent;
            repo.DbRemoveUser(delstu);
            update();
        }

        private void NewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserPopup.IsOpen = true;
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new dbDataContext())
            {
                if (NewName.Text == "" || NewLastName.Text == ""
                    || NewEmail.Text == "" || NewUserName.Text == ""
                    || NewPassword.Text == "")
                {
                    MessageBox.Show("Fyll i alla fält");
                }
                else
                {
                    string firstName = NewName.Text;
                    string lastName = NewLastName.Text;
                    string email = NewEmail.Text;
                    string userName = NewUserName.Text;
                    string password = NewPassword.Text;
                    dbStudent stu = new dbStudent
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        UserName = userName,
                        Password = password
                    };

                    db.Students.Add(stu);
                    db.SaveChanges();
                    popupclose();
                }
                

               
                

            }
        }
        private void popupclose()
        {
            AddUserPopup.IsOpen = false;
            NewName.Clear();
            NewLastName.Clear();
            NewEmail.Clear();
            NewUserName.Clear();
            NewPassword.Clear();
            update();
        }

        private void btnCloseUserPopup_click(object sender, RoutedEventArgs e)
        {
            popupclose();
        }

        private void NewExamBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ContentFrame.Navigate(new CreateQuiz());
            //FrameCreateQuiz.Navigate(new CreateQuiz());
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("popping");
            SendQuizPopup.IsOpen = true;
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedQuiz = cbxQuizzes.SelectedItem as dbQuiz;
            if (selectedQuiz == null)
            {
                MessageBox.Show("Välj ett prov");
            }
            else
            {
                double IGCounter = 0;
                double GCounter = 0;
                double VGCounter = 0;
                double Totalcounter = 0;
                double TimeCounter = 0;
                double ScoreCounter = 0;
                StatisticsListView.ItemsSource = repo.UpdateStudentQuizzesList(selectedQuiz.dbQuizId);
                foreach (var item in repo.UpdateStudentQuizzesList(selectedQuiz.dbQuizId))
                {
                    Totalcounter++;
                    TimeCounter += item.Time;
                    ScoreCounter += item.Score;
                    if (item.FinalGrade == "IG")
                    {
                        IGCounter++;
                    }
                    else if (item.FinalGrade == "G")
                    {
                        GCounter++;
                    }
                    else if (item.FinalGrade == "VG")
                    {
                        VGCounter++;
                    }
                }
                 
                
                IGLabel.Content = IGCounter + " " + "IG på provet" + " " + ((IGCounter / Totalcounter) * 100) + "%";
                GLabel.Content = GCounter + " " + "G på provet" + " " + ((GCounter / Totalcounter) * 100) + "%";
                VGLabel.Content = VGCounter + " " + "VG på provet" + " " + ((VGCounter / Totalcounter) * 100) + "%";
                ScoreLable.Content = (ScoreCounter/Totalcounter) + " Snittpoäng";
                TimeLable.Content = (TimeCounter/Totalcounter) + "(Minuter) Snittid";
            }
            
        }

        private void DefaultSortBtn_Click(object sender, RoutedEventArgs e)
        {
            StatisticsListView.ItemsSource = repo.StudentQuizzesList();
            IGLabel.Content = "";
            GLabel.Content = "";
            VGLabel.Content = "";
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StatisticsListView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("student.FirstName", ListSortDirection.Descending));

        }

        private void btnCancelSendout_click(object sender, RoutedEventArgs e)
        {
            SendQuizPopup.IsOpen = false;
        }

        private void btnSendout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Testen har skickats ut!");
            SendQuizPopup.IsOpen = false;
        }

        private void GradeBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock GradeBlock = sender as TextBlock;
            if(GradeBlock.Text.Equals("IG"))
                GradeBlock.Foreground = Brushes.Red;
            else if (GradeBlock.Text.Equals("G") || GradeBlock.Text.Equals("VG"))
                GradeBlock.Foreground = Brushes.Green;
        }
    }
}
