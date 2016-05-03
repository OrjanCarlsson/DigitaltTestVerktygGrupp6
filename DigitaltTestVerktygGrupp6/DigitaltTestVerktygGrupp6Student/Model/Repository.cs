using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class Repository
    {
        public List<dbQuizs> GetQuizes(dbStudents student)
        {
            using (var model = new QuizModel())
            {
                var query = from quiz in model.dbQuizs
                            where quiz.dbStudentQuizs.Any(c => c.dbStudentId == student.dbStudentId)
                            select quiz;

                return query.ToList();
            }
        }

        public List<Question> GetQuestions(dbQuizs quiz)
        {
            List<Question> questions = new List<Question>();
            using (var model = new QuizModel())
            {
                var query = from question in model.dbQuestions
                            where question.dbQuizId == quiz.dbQuizId
                            select question;
                foreach (var q in query)
                {
                    if (q.Type.Equals(QuestionType.Single) || q.Type.Equals(QuestionType.Multi))
                        questions.Add(new MultiQuestion(q));
                    else if (q.Type.Equals(QuestionType.Text.ToString()))
                        questions.Add(new TextQuestion(q));
                    else if (q.Type.Equals(QuestionType.Rank))
                        questions.Add(new RankingQuestion(q));
                }
                return questions;
            }
        }
    }
}
