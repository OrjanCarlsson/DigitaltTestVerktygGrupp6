using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class Repository
    {
        public List<Quizs> GetQuizes(Students student)
        {
            using (var model = new ModelQuiz())
            {
                var query = from quiz in model.Quizs
                            where quiz.StudentQuizs.Any(c => c.StudentId == student.StudentId)
                            select quiz;
                return query.ToList();
            }
        }

        public List<Question> GetQuestions(Quizs quiz)
        {
            List<Question> questions = new List<Question>();
            using (var model = new ModelQuiz())
            {
                var query = from question in model.Questions
                            where question.QuizId == quiz.QuizId
                            select question;
                foreach (var q in query)
                {
                    if (q.Type == 1 || q.Type == 2)
                        questions.Add(new MultiQuestion(q));
                    else if (q.Type == 3)
                        questions.Add(new TextQuestion(q));
                    else if (q.Type == 4)
                        questions.Add(new RankingQuestion(q));
                }
                return questions;
            }
        }
    }
}
