using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Database
{
    public class dbAlternative
    {
        public int dbAlternativeId { get; set; }
        public string Text { get; set; }
        public int IsCorrect { get; set; }

        public int dbQuestionId { get; set; }

        public virtual dbQuestion dbQuestions { get; set; }
    }
}
