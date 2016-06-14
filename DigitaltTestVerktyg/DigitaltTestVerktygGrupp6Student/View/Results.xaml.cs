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
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        private QuizViewmodel viewModel;

        public Results()
        {
            InitializeComponent();
            viewModel = QuizViewmodel.Instance;
            DataContext = viewModel;

            if (viewModel.SelectedQuiz.Feedback == true )
            {
                txtWithFeedback.Visibility = Visibility.Visible;
            }
            else
            {
                txtWithOutFeedback.Visibility = Visibility.Visible;

            }
            //IF quiz.feedback = true; show txtWithFeedback
            //ELSE show txtWithOutFeedback
            
        }

        private void btnFinishQuiz_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Reset();
            viewModel.NavigateTo(new QuizSelection());
        }
    }
}
