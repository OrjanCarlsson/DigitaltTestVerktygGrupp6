using DigitaltTestVerktygGrupp6Wpf.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    class Alternative
    {
        public virtual bool IsChecked { get; set; }
        public virtual string UserText { get; set; }

        public string Text { get; set; }
        public int IsCorrect { get; set; }

    }
}
