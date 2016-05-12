using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class RankingQuestion : Question
    {

        public List<string> Numbers { get; private set; }

        private Alternative tempAlt;
        private int selectedIndex = 0;
        private bool firstSelection = true, changing = true;

        public Alternative AlternativesOrder
        {
            set
            {
                if (firstSelection)
                {
                    tempAlt = value;
                    selectedIndex = Alternatives.IndexOf(value);
                    firstSelection = false;
                    changing = true;
                }
                else if (changing)
                {
                    changing = false;

                    var index = Alternatives.IndexOf(value);
                    Alternatives[selectedIndex] = value;
                    Alternatives[index] = tempAlt;

                    firstSelection = true;
                }
            }
        }

        private void CheckAnswers()
        {
            userCorrectAnswers = 0;
            foreach (var alt in Alternatives)
            {
                if (alt.IsCorrect == Alternatives.IndexOf(alt))
                    userCorrectAnswers++;
                else
                    userCorrectAnswers--;
            }
        }

        public override bool AnswerCorrect()
        {
            CheckAnswers();
            return correctAnswers == userCorrectAnswers;
        }

        public RankingQuestion(dbQuestions question) : base(question) { }

        protected override void AddAlternatives(dbQuestions question)
        {
            Numbers = new List<string>();
            int nr = 1;
            foreach (var alt in question.dbAlternatives.OrderBy(a => Guid.NewGuid()).ToList())
            {
                Alternatives.Add(new RankingAlternative(alt, this));
                Numbers.Add(nr++.ToString() + ".");
                correctAnswers++;
            }
            answered = 1;
        }
    }
}
