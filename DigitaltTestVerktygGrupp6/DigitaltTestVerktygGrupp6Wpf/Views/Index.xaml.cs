using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Model;
using DigitaltTestVerktygGrupp6Wpf.ViewModel;
using System;
using System.Collections.Generic;
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
        Repository repo = new Repository();
        public List<dbStudent> students;
        public Index()
        {
            InitializeComponent();
            students = repo.StudentsList();
            UserListView.ItemsSource = students;
            // FrameCreateQuiz.NavigationService.GoBack();
            viewModel = CreateQuizModel.StaticModel;

            //viewModel.ContentFrame = FrameCreateQuiz;
            //viewModel.NavigateTo(new CreateQuiz());
        }
        public void update()
        {
            students = repo.StudentsList();
            UserListView.ItemsSource = students;
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
                dbStudent stu = new dbStudent
                {
                    FirstName = NewName.Text,
                    LastName = NewLastName.Text,
                    Email = NewEmail.Text,
                    UserName = NewUserName.Text,
                    Password = NewPassword.Text
                };

                db.Students.Add(stu);
                db.SaveChanges();
                AddUserPopup.IsOpen = false;
                NewName.Clear();
                NewLastName.Clear();
                NewEmail.Clear();
                NewUserName.Clear();
                NewPassword.Clear();
                update();

            }
        }

        private void btnCloseUserPopup_click(object sender, RoutedEventArgs e)
        {
            AddUserPopup.IsOpen = false;
            NewName.Clear();
            NewLastName.Clear();
            NewEmail.Clear();
            NewUserName.Clear();
            NewPassword.Clear();
        }

        private void NewExamBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ContentFrame.Navigate(new CreateQuiz());
            //FrameCreateQuiz.Navigate(new CreateQuiz());
        }
    }
}
