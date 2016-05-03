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
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Page
    {
        private QuizViewmodel viewModel;
        private ControlTemplate radioTemplate, checkTemplate, textTemplate, rankingTemplate;

        public Quiz()
        {
            InitializeComponent();
            radioTemplate = Resources["RadioTemplate"] as ControlTemplate;
            checkTemplate = Resources["CheckTemplate"] as ControlTemplate;
            textTemplate = Resources["TextTemplate"] as ControlTemplate;
            rankingTemplate = Resources["RankingTemplate"] as ControlTemplate;
            viewModel = QuizViewmodel.Instance;
            viewModel.QuizSetup();
            DataContext = viewModel;
            ShowQuestion();
            viewModel.NextQuestionEvent += ShowQuestion;
        }

        private void ShowQuestion()
        {
           switch(viewModel.ActiveQuestion.Type)
            {
                case 1:
                    AlternativesContent.Template = radioTemplate;
                    break;
                case 2:
                    AlternativesContent.Template = checkTemplate;
                    break;
                case 3:
                    AlternativesContent.Template = textTemplate;
                    break;
                case 4:
                    AlternativesContent.Template = rankingTemplate;
                    break;
            }
        }
    }
}
