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

        public override bool AnswerCorrect()
        {
            foreach (Alternative alt in Alternatives)
            {
                if (alt.IsCorrect == 1 && alt.IsChecked)
                    userCorrectAnswers++;
                else if (alt.IsChecked)
                    userCorrectAnswers--;
            }
            if (userCorrectAnswers == correctAnswers)
                return true;
            else
                return false;
        }
    }
}
