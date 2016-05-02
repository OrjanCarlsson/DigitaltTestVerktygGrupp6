using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class TextQuestion : Question
    {
        private string userText;
        public string UserText
        {
            get { return userText; }
            set
            {
                if (value.ToLower().Equals(Alternatives[0].Text.ToLower()))
                {
                    userCorrectAnswers = 1;
                }
                else
                    userCorrectAnswers = -1;
                userText = value;
                answered = userText.Length;
            }
        }
        public TextQuestion(Questions question) : base(question)
        {
            correctAnswers = 1;
        }
    }
}
