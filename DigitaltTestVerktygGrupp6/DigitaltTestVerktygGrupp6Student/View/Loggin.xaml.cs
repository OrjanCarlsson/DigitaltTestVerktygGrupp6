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
using DigitaltTestVerktygGrupp6Student.Model;
using DigitaltTestVerktygGrupp6Student.View;
using DigitaltTestVerktygGrupp6Student.ViewModel;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.View
{
    /// <summary>
    /// Interaction logic for Loggin.xaml
    /// </summary>
    public partial class Loggin : Page
    {
        Repository repo = new Repository();
        private QuizViewmodel viewModel;
        public Loggin()
        {
            InitializeComponent();
        }

        private void LogginBtn_Click(object sender, RoutedEventArgs e)
        {
           dbStudents loguser = repo.GetUser(UserLogBox.Text, PassLogBox.Password);
            if (loguser == null)
            {
                MessageBox.Show("Ingen användare hittades");
            }
            else
            {
                viewModel = QuizViewmodel.Instance;
                viewModel.SelectionSetup(loguser);
                viewModel.NavigateTo(new QuizSelection());
            }

        }
    }
}
