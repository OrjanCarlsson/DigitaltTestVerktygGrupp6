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
using DigitaltTestVerktygGrupp6Wpf.Views;
using DigitaltTestVerktygGrupp6Wpf.ViewModel;

namespace DigitaltTestVerktygGrupp6Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CreateQuizModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            //using (var db = new ModelQuiz())
            //{
            //    var query = db.Students.ToList();
            //    foreach (var item in query)
            //    {
            //        MessageBox.Show(item.FirstName);
            //    }
            //}

            viewModel = CreateQuizModel.StaticModel;
           
            viewModel.ContentFrame = FrameCreateQuiz;
            viewModel.NavigateTo(new Index());
        }

        //private void btnCloseUserPopup_click(object sender, RoutedEventArgs e)
        //{
        //    popupclose();
        //}
    }
}
