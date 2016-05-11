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
                            where quiz.dbStudentQuizs.Any(c => c.dbStudentId == student.dbStudentId && c.FinalGrade == null)
                            select quiz;

                return query.ToList();
            }


        }

        public List<dbStudentQuizs> GetFinishedQuizes(dbStudents student)
        {
            using (var model = new QuizModel())
            {
                //var query = from quiz in model.dbQuizs
                //            where quiz.dbStudentQuizs.Any(c => c.dbStudentId == student.dbStudentId && c.FinalGrade != null)
                //            select quiz;

                return model.dbStudentQuizs.Include("dbStudents").Include("dbQuizs").Where(a => a.dbStudentId == student.dbStudentId).ToList();

                //return query.ToList();
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
                    if (q.Type.Equals(QuestionType.Single.ToString()) || q.Type.Equals(QuestionType.Multi.ToString()))
                        questions.Add(new MultiQuestion(q));
                    else if (q.Type.Equals(QuestionType.Text.ToString()))
                        questions.Add(new TextQuestion(q));
                    else if (q.Type.Equals(QuestionType.Rank.ToString()))
                        questions.Add(new RankingQuestion(q));
                }

                return questions;
            }
        }

        internal void SaveResult(dbStudents activeStudent, dbQuizs selectedQuiz, int score, int time, double totalScore)
        {
            using (var model = new QuizModel())
            {
                var query = from studentQuiz in model.dbStudentQuizs
                            where studentQuiz.dbStudentId == activeStudent.dbStudentId && studentQuiz.dbQuizId == selectedQuiz.dbQuizId
                            select studentQuiz;

                var sq = query.First();
                sq.Score = score;
                sq.Time = time;

                string grade;

                double GThreshold = (double)(selectedQuiz.GradeG) / 100;
                double VGThreshold = (double)(selectedQuiz.GradeVG) / 100;

                if (score >= VGThreshold)
                    grade = "VG";
                else if (score >= GThreshold)
                    grade = "G";
                else
                    grade = "IG";

                sq.FinalGrade = grade;

                model.SaveChanges();
            }
        }

        public dbStudents GetUser(string user, string password)
        {
            using (var model = new QuizModel())
            {
                foreach (dbStudents item in model.dbStudents)
                {
                    if (item.UserName == user && item.Password == password)
                    {
                        return item;
                    }
                    
                }

                return null;
            }
        }
    }
}
