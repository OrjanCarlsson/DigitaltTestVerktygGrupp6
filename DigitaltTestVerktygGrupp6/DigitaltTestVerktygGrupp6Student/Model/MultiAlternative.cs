﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.ViewModel;

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
                ChangeCounter();
            }
        }

        public MultiAlternative(Alternatives alt, Question q) : base(alt, q) { }

        private void ChangeCounter()
        {
            if (IsCorrect == 1 && isChecked)
                ParentQuestion.userCorrectAnswers++;
            else
                ParentQuestion.userCorrectAnswers--;
        }
    }
}
