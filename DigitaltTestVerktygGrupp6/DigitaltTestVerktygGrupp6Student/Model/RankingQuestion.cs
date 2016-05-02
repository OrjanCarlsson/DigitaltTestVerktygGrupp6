using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class RankingQuestion : Question
    {

        public List<int> Numbers { get; private set; }

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

                    CheckAnswers();

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

        public RankingQuestion(Questions question) : base(question) { }

        protected override void AddAlternatives(Questions question)
        {
            Numbers = new List<int>();
            int nr = 1;
            foreach (var alt in question.Alternatives.ToList())
            {
                Alternatives.Add(new RankingAlternative(alt, this));
                Numbers.Add(nr++);
                correctAnswers++;
            }
            answered = 1;
        }
    }
}
