using DigitaltTestVerktygGrupp6Student.Model;
using DigitaltTestVerktygGrupp6Student.ViewModel;
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

namespace DigitaltTestVerktygGrupp6Student.View
{
    /// <summary>
    /// Interaction logic for FinishedQuizes.xaml
    /// </summary>
    public partial class FinishedQuizes : Page
    {
        private QuizViewmodel viewModel;
        private Repository repo;
        public FinishedQuizes()
        {
            InitializeComponent();
            viewModel = QuizViewmodel.Instance;
            DataContext = viewModel;
            
        }

        private void QuizList_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as ListView).SelectedIndex = 0;
        }

        private void btnGoToQuizSelect_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NavigateTo(new QuizSelection());
        }
    }
}
