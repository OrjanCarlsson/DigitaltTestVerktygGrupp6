using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Model;
using DigitaltTestVerktygGrupp6Wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        int clickCounter = 0;
        int rangordningsCounter = -1;
        int calcPoints;
        double totalPoints;
        CreateQuizModel viewModel;
        ControlTemplate showAnswersToEdit, showQuestionToEdit;
        public CreateQuiz()
        {
            InitializeComponent();
            viewModel = CreateQuizModel.StaticModel;
            DataContext = viewModel;

            showAnswersToEdit = Resources["ShowAnswersToEdit"] as ControlTemplate;
            showQuestionToEdit = Resources["ShowQuestionToEdit"] as ControlTemplate;

            showAnswersContent.Template = showAnswersToEdit;
            showQuestionContent.Template = showQuestionToEdit;
            cmbType.SelectedIndex = 2;
            showQuestionContent.Visibility = Visibility.Collapsed;
            showAnswersContent.Visibility = Visibility.Collapsed;
            comboBoxTimeSetup();
        }

        private void comboBoxTimeSetup()
        {
            int[] comboTime = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120 };
            cmbTime.ItemsSource = comboTime;
            cmbTime.SelectedIndex = 0;
        }
        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddQPopup.IsOpen = true;
        }

        private void btnClosePopup_Click(object sender, RoutedEventArgs e)
        {
            AddQPopup.IsOpen = false;
            cmbType.IsEnabled = true;
            txtAnswer.IsEnabled = true;
            btnAddAnswer.IsEnabled = true;
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
                Text = viewModel.alternativeList[counter - 1].Text,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 6, 0, 0)
            };
            if (chkAnswer.IsChecked == true)
            {
                newTextBlock2.Foreground = Brushes.Green;
            }
            return newTextBlock2;
        }

        private Button makeRemoveButton()
        {
            var bc = new BrushConverter();
            var btnDelete = new Button()
            {
                Content = "-",
                Width = 20,
                Margin = new Thickness(0, 4, 0, 0),
                Background = (Brush)bc.ConvertFrom("#FFFF665E")
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
        private void btnAddAnswer_Click(object sender, RoutedEventArgs e)
        {
            clickCounter++;
            rangordningsCounter++;
            cmbType.IsEnabled = false;
            int answerChecker;
            if (chkAnswer.IsChecked == true)
            {
                answerChecker = 1;
            }
            else
            {
                answerChecker = 0;
            }

            if (String.IsNullOrEmpty(txtAnswer.Text))
            {
                MessageBox.Show("Type in answer before adding");
            }
            else
            {
                if (cmbType.SelectedIndex == 1) //Rangordnings fråga
                {
                    viewModel.alternativeList.Add(new dbAlternative
                    {
                        Text = txtAnswer.Text,
                        IsCorrect = rangordningsCounter
                    });
                }
                else if (cmbType.SelectedIndex == 0)
                {
                    viewModel.alternativeList.Add(new dbAlternative
                    {
                        Text = txtAnswer.Text,
                        IsCorrect = 1
                    });
                    txtAnswer.IsEnabled = false;
                    btnAddAnswer.IsEnabled = false;
                }
                else
                {
                    viewModel.alternativeList.Add(new dbAlternative
                    {
                        Text = txtAnswer.Text,
                        IsCorrect = answerChecker
                    });
                }
                
                txtAnswer.Clear();
            
                if (panelAnswerText.Children.Count < 8)
                {
                    counter++;
                    panelAnswers.Children.Add(makeTextBlock2());
                    panelAnswerText.Children.Add(makeTextBlock());
                    panelRemoveAnswer.Children.Add(makeRemoveButton());
                }
                chkAnswer.IsChecked = false;
            }
        }
        private void testing(int index)
        {
            viewModel.alternativeList.RemoveAt(index);
        }
        private void btnRemoveAnswer(object sender, RoutedEventArgs e)
        {
            if (panelAnswerText.Children.Count > 1)
            {
                counter--;
                panelAnswers.Children.RemoveAt(panelAnswers.Children.Count - 1);
                panelAnswerText.Children.RemoveAt(panelAnswerText.Children.Count - 1);
                panelRemoveAnswer.Children.RemoveAt(panelRemoveAnswer.Children.Count - 1);
                testing(panelAnswers.Children.Count-1);
            }
            if (panelRemoveAnswer.Children.Count == 1)
            {
                cmbType.IsEnabled = true;
            }
            txtAnswer.IsEnabled = true;
            btnAddAnswer.IsEnabled = true;
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbType.SelectedIndex == 0 || cmbType.SelectedIndex == 1)
            {
                chkAnswer.Visibility = Visibility.Collapsed;
            }
            else
                chkAnswer.Visibility = Visibility.Visible;
        }

        private void btnAddQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtQuizName.Text))
            {
                MessageBox.Show("Must type in name for the Quiz");
            }
            else if (String.IsNullOrEmpty(txtQuizIntro.Text))
            {
                MessageBox.Show("Must type in an intro for the Quiz");
            }
            else if (viewModel.questionList.Count <= 0)
            {
                MessageBox.Show("Must add atleast one question");
            }
            else
            {
                viewModel.quizList.Add(new dbQuiz
                {
                    Name = txtQuizName.Text,
                    Intro = txtQuizIntro.Text,
                    Questions = viewModel.questionList,
                    GradeG = gradeG(),
                    GradeVG = gradeVG(),
                    Feedback = true,
                    TimeLimit = int.Parse(cmbTime.SelectedItem.ToString())
                });

                using (var db = new dbDataContext())
                {
                    foreach (dbQuiz quiz in viewModel.quizList)
                    {
                        db.Quizes.Add(quiz);
                    }
                    db.SaveChanges();
                }
                viewModel.ContentFrame.Navigate(new Index());

                viewModel.questionList = new ObservableCollection<dbQuestion>();
                viewModel.quizList = new ObservableCollection<dbQuiz>();
            }
        }

        private int gradeVG()
        {
            double gPoint = totalPoints;
            gPoint = gPoint * 0.8;
            int gradeVG = (int)Math.Round(gPoint, 0);
            return gradeVG;
        }
        private int gradeG()
        {
            double vgPoint = totalPoints;
            vgPoint = vgPoint * 0.5;
            int gradeG = (int)Math.Round(vgPoint, 0);
            return gradeG;
        }

        private void listQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showQuestionContent.Visibility = Visibility.Visible;
            showAnswersContent.Visibility = Visibility.Visible;
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            cmbType.IsEnabled = true;
            txtAnswer.IsEnabled = true;
            btnAddAnswer.IsEnabled = true;
            rangordningsCounter = -1;
            counter = 0;
            if (String.IsNullOrEmpty(txtQuestion.Text))
            {
                MessageBox.Show("Type in a question");
            }
            else if (String.IsNullOrEmpty(txtPoints.Text))
            {
                MessageBox.Show("Type in a points");
            }
            else if (String.IsNullOrEmpty(txtAnswer.Text) && viewModel.alternativeList.Count <= 0)
            {
                MessageBox.Show("Type in an answer");
            }
            else if (viewModel.alternativeList.Count <= 0)
            {
                MessageBox.Show("Need to add atleast one answer");
            }
            else
            {
                viewModel.questionList.Add(new dbQuestion
                {
                    Text = txtQuestion.Text,
                    Type = cmbType.Text,
                    Points = int.Parse(txtPoints.Text),
                    Alternatives = viewModel.alternativeList
                });

                foreach (var item in viewModel.questionList)
                {
                    calcPoints = item.Points;
                }
                totalPoints += calcPoints;

                panelAnswers.Children.RemoveRange(1, clickCounter);
                panelAnswerText.Children.RemoveRange(1, clickCounter);
                panelRemoveAnswer.Children.RemoveRange(1, clickCounter);
                txtAnswer.Clear();
                txtPoints.Clear();
                txtQuestion.Clear();

                viewModel.alternativeList = new ObservableCollection<dbAlternative>();
                AddQPopup.IsOpen = false;

            }
            
        }

    }
}
