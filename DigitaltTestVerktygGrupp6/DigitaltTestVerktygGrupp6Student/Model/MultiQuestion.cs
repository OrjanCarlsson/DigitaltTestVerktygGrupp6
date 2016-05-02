using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class MultiQuestion : Question
    {
        public static int UserCorrectAnswers = 0;
        public MultiQuestion(Questions question) : base(question) { }

        protected override void AddAlternatives(Questions question)
        {
            foreach (var alt in question.Alternatives.ToList())
            {
                Alternatives.Add(new MultiAlternative(alt, this));
                if (alt.IsCorrect == 1)
                    correctAnswers++;
            }
        }
    }
}
