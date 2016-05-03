using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class MultiQuestion : Question
    {
        public static int UserCorrectAnswers = 0;
        public MultiQuestion(dbQuestions question) : base(question) { }

        protected override void AddAlternatives(dbQuestions question)
        {
            foreach (var alt in question.dbAlternatives.ToList())
            {
                Alternatives.Add(new MultiAlternative(alt, this));
                if (alt.IsCorrect == 1)
                    correctAnswers++;
            }
        }
    }
}
