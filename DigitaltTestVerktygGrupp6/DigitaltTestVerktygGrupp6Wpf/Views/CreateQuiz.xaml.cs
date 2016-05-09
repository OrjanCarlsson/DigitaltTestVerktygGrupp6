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
        //IList<dbAlternative> alternativeList = new List<dbAlternative>();
        ObservableCollection<dbAlternative> alternativeTemp = new ObservableCollection<dbAlternative>();
        //ObservableCollection<Question> questionTemp = new ObservableCollection<Question>();

        
        ControlTemplate showAnswersToEdit, showQuestionToEdit;
        public CreateQuiz()
        {
            InitializeComponent();
            viewModel = CreateQuizModel.StaticModel;
            DataContext = viewModel;

            showAnswersToEdit = Resources["ShowAnswersToEdit"] as ControlTemplate;
            showQuestionToEdit = Resources["ShowQuestionToEdit"] as ControlTemplate;
            //showAnswers = Resources["showAnswers"] as ControlTemplate;

            showAnswersContent.Template = showAnswersToEdit;
            showQuestionContent.Template = showQuestionToEdit;
            cmbType.SelectedIndex = 2;
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
                Text = alternativeTemp[counter - 1].Text,
                // Height = 20,
                // Width = 147,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 6, 0, 0)
            };
            //test.Add(newTextBox);
            if (chkAnswer.IsChecked == true)
            {
                newTextBlock2.Foreground = Brushes.Green;
            }
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
            clickCounter++;
            rangordningsCounter++;
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

                    alternativeTemp.Add(new dbAlternative
                    {
                        Text = txtAnswer.Text,
                        IsCorrect = rangordningsCounter
                    });

                }
                else
                {
                    viewModel.alternativeList.Add(new dbAlternative
                    {
                        Text = txtAnswer.Text,
                        IsCorrect = answerChecker
                    });

                    alternativeTemp.Add(new dbAlternative
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
                    // panelCheckBox.Children.Add(checkAnswer());
                }
                chkAnswer.IsChecked = false;
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
                viewModel.alternativeList.RemoveAt(0);
            }
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
                //gradeG(totalPoints);
                //gradeVG(totalPoints);
                //totalPoints = totalPoints * 0.5;
                //int gradeG = (int)Math.Round(totalPoints, 0);

                viewModel.quizList.Add(new dbQuiz
                {
                    Name = txtQuizName.Text,
                    Intro = txtQuizIntro.Text,
                    Questions = viewModel.questionList,
                    GradeG = gradeVG(),
                    GradeVG = gradeG()
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

            }
        }


        private int gradeVG()
        {
            //int gradeVG = totalPoints * (int)Math.Round(0.8);
            double gPoint = totalPoints;
            gPoint = gPoint * 0.8;
            int gradeVG = (int)Math.Round(gPoint, 0);
            return gradeVG;
        }
        private int gradeG()
        {
            //int gradeG = totalPoints * (int)Math.Round(0.5);
            //return gradeG;
            double vgPoint = totalPoints;
            vgPoint = vgPoint * 0.5;
            int gradeG = (int)Math.Round(vgPoint, 0);
            return gradeG;
        }

        private void btnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            rangordningsCounter = -1;
               counter = 0;
            //int listCounter = 0;
            //questionList = new List<dbQuestion>();
            //listCounter++;
            //if (txtQuestion.Text == string.Empty || txtPoints.Text == string.Empty)
            //{
            //    MessageBox.Show("HERPO");
            //}
            if (String.IsNullOrEmpty(txtQuestion.Text))
            {
                MessageBox.Show("Type in a question");
            }
            else if (String.IsNullOrEmpty(txtPoints.Text))
            {
                MessageBox.Show("Type in a points");
            }
            else if (String.IsNullOrEmpty(txtAnswer.Text) && alternativeTemp.Count <= 0)
            {
                MessageBox.Show("Type in an answer");
            }
            else if (alternativeTemp.Count <= 0)
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
                    Alternatives = alternativeTemp
                });
                //questionTemp.Add(new Question
                //{
                //    Text = txtQuestion.Text,
                //    Type = cmbType.Text,
                //    Points = int.Parse(txtPoints.Text),
                //    Alternatives = alternativeTemp
                //});

                //calculatePoints();

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

                
                alternativeTemp = new ObservableCollection<dbAlternative>();
                //viewModel.alternativeList.Clear();
            
                AddQPopup.IsOpen = false;
            }
            
        }

    }
}
