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
using DigitaltTestVerktygGrupp6Wpf.Model;
using DigitaltTestVerktygGrupp6Wpf.Database;

namespace DigitaltTestVerktygGrupp6Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repo = new Repository();
        
        
        public MainWindow()
        {
            InitializeComponent();
            update();
        }
        public void update()
        {
            ExamListView.ItemsSource = repo.QuizsList();
            UserListView.ItemsSource = repo.StudentsList();
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
                popupclose();
                update();

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
        }

        private void btnCloseUserPopup_click(object sender, RoutedEventArgs e)
        {
            popupclose();
        }
    }
}
