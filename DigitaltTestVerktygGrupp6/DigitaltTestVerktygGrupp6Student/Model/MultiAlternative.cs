using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.ViewModel;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class MultiAlternative : Alternative
    {
        private bool isChecked;

        public override bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (isChecked)
                    ParentQuestion.answered++;
                else
                    ParentQuestion.answered--;
            }
        }

        public MultiAlternative(dbAlternatives alt, Question q) : base(alt, q) { }

    }
}
