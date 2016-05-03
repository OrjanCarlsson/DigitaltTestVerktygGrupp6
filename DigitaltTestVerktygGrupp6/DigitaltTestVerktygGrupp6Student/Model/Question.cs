using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    public enum QuestionType
    {
        Single,
        Multi,
        Text,
        Rank
    }
    class Question
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public string Image { get; set; }
        public ObservableCollection<Alternative> Alternatives { get; set; }

        protected int correctAnswers = 0;
        public int userCorrectAnswers = 0, answered = 0;

        public Question(dbQuestions question)
        {
            Alternatives = new ObservableCollection<Alternative>();
            AddAlternatives(question);
            Type = question.Type;
            Text = question.Text;
            Points = question.Points;
            Image = question.Image;
        }

        protected virtual void AddAlternatives(dbQuestions question)
        {
            foreach (var alt in question.dbAlternatives.ToList())
            {
                Alternatives.Add(new Alternative(alt, this));
            }
        }

        public bool AnswerCorrect()
        {
            return correctAnswers == userCorrectAnswers;
        }

        public bool IsAnswered()
        {
            return answered > 0;
        }
    }
}
