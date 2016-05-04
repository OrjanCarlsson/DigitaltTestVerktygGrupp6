using DigitaltTestVerktygGrupp6Wpf.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DigitaltTestVerktygGrupp6Wpf.ViewModel
{
    class CreateQuizModel : INotifyPropertyChanged
    {
        public Frame ContentFrame { get; set; }
        private static CreateQuizModel staticModel;
       // public dbQuestion Questions { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NavigateTo(Page page)
        {
            ContentFrame.Navigate(page);
           // Questions = new dbQuestion
        }

        public static CreateQuizModel StaticModel
        {
            get
            {
                if (staticModel == null)
                    staticModel = new CreateQuizModel();
                return staticModel;
            }
        }
    }
}
