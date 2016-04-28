using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public string Image { get; set; }
        public int Points { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; }
    }
}
