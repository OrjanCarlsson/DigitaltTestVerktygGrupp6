using DigitaltTestVerktygGrupp6Wpf.Database;
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
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : Page
    {
        int counter = 0;

        CreateQuizModel viewModel;
        IList<dbAlternative> alternativeList = new List<dbAlternative>();

        IList<dbAlternative> alternativeObj = new List<dbAlternative>();
        
        ControlTemplate showQuestion, showAnswers;
        public CreateQuiz()
        {
            InitializeComponent();
            viewModel = CreateQuizModel.StaticModel;
            DataContext = viewModel;

            showQuestion = Resources["showQuestion"] as ControlTemplate;
            showAnswers = Resources["showAnswers"] as ControlTemplate;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddQPopup.IsOpen = true;
        }

        private void btnClosePopup_Click(object sender, RoutedEventArgs e)
        {
            AddQPopup.IsOpen = false;
        }

        private TextBlock makeTextBlock()
        {
            var textBrush = new BrushConverter();
            var newTextBlock = new TextBlock()
            {
                Text = $"Svar nr. {0 + counter}",
                Margin = new Thickness(0, 6, 0, 0),
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = (Brush)textBrush.ConvertFrom("#FF2B2A2A")
            };
            return newTextBlock;
        }

        private TextBlock makeTextBlock2()
        {

            var newTextBlock2 = new TextBlock()
            {
                Text = alternativeList[counter - 1].Text,
                // Height = 20,
                // Width = 147,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 6, 0, 0)
            };
            //test.Add(newTextBox);
            return newTextBlock2;
        }

        private Button makeRemoveButton()
        {
            var btnDelete = new Button()
            {
                Content = "-",
                Width = 20,
                Margin = new Thickness(0, 4, 0, 0)
            };
            btnDelete.Click += btnRemoveAnswer;
            return btnDelete;
        }

        private CheckBox checkAnswer()
        {
            var newCheckBox = new CheckBox()
            {
                Margin = new Thickness(8, 3, 0, 6)
            };
            return newCheckBox;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int answerChecker;
            if (chkAnswer.IsChecked == true)
            {
                answerChecker = 1;
            }
            else
            {
                answerChecker = 0;
            }

            alternativeList.Add(new dbAlternative
            {
                Text = txtAnswer.Text,
                IsCorrect = answerChecker
            });


            if (panelAnswerText.Children.Count < 8)
            {
                counter++;
                panelAnswers.Children.Add(makeTextBlock2());
                panelAnswerText.Children.Add(makeTextBlock());
                panelRemoveAnswer.Children.Add(makeRemoveButton());
                // panelCheckBox.Children.Add(checkAnswer());
            }
        }

        private void btnRemoveAnswer(object sender, RoutedEventArgs e)
        {
            if (panelAnswerText.Children.Count > 1)
            {
                counter--;
                panelAnswers.Children.RemoveAt(panelAnswers.Children.Count - 1);
                panelAnswerText.Children.RemoveAt(panelAnswerText.Children.Count - 1);
                panelRemoveAnswer.Children.RemoveAt(panelRemoveAnswer.Children.Count - 1);
                //panelCheckBox.Children.RemoveAt(panelCheckBox.Children.Count - 1);
                alternativeList.RemoveAt(0);
            }
        }

        private void btnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            int listCounter = 0;
            IList<dbQuestion> questionList = new List<dbQuestion>();
            listCounter++;
            questionList.Add(new dbQuestion
            {
                Text = txtQuestion.Text,
                Type = cmbType.Text,
                Points = int.Parse(txtPoints.Text),
                Alternatives = alternativeList
            });

            AddQPopup.IsOpen = false;

            showQuestionsControl.Template = showQuestion;
            showAnswersControl.Template = showAnswers;


            //TextBlock displayQuestionNumber = new TextBlock()
            //{
            //    Text = questionList.Count.ToString()
            //};


            //panelDisplayQ.Children.Add(displayQuestionNumber);

            //TextBlock displayQuestionText = new TextBlock()
            //{
            //    Text = questionList[listCounter - 1].Text,

            //};
            //panelDisplayQText.Children.Add(displayQuestionText);

            //foreach (var item in alternativeList)
            //{
            //    TextBlock displayAnswerText = new TextBlock()
            //    {
            //        Text = item.Text
            //    };
            //    TextBlock displayAnswerNumber = new TextBlock()
            //    {
            //        Text = item.AlternativeId.ToString()
            //    };
            //    panelDisplayQText.Children.Add(displayAnswerText);
            //    panelDisplayQ.Children.Add(displayAnswerNumber);
            //}




        }

    }
}
