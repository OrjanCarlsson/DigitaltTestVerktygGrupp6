using DigitaltTestVerktygGrupp6Wpf.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    public enum QuestionType
    {
        Single,
        Multi,
        Text,
        Rank
    }
    class Question
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public string Image { get; set; }
        public ObservableCollection<Alternative> Alternatives { get; set; }

        protected int correctAnswers = 0;
        public int userCorrectAnswers = 0, answered = 0;

    }
}
