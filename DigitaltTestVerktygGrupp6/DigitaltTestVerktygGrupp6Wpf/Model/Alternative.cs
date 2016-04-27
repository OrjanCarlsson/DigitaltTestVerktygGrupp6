using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    class Alternative
    {
        public int AlternativeId { get; set; }
        public string Text { get; set; }
        public int IsCorrect { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
