using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Wpf.Database;
using DigitaltTestVerktygGrupp6Wpf.Views;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    public class Repository
    {
        public List<dbStudent> StudentsList()
        {
            using (var db = new dbDataContext())
            {
                return db.Students.ToList();
            }
        }
        public List<dbStudentQuiz> StudentQuizzesList()
        {
            using (var db = new dbDataContext())
            {
                return db.StudentQuizzes.Include("student").Include("quiz").Include("quiz.Questions").ToList();
            }
        }
        public List<dbStudentQuiz> UpdateStudentQuizzesList(int quizId)
        {
            using (var db = new dbDataContext())
            {
                return db.StudentQuizzes.Include("student").Include("quiz").Where(a => a.dbQuizId == quizId).ToList();
            }
        }

        public ObservableCollection<Student> FreeStudentQuizList(int quizId)
        {
            ObservableCollection<Student> studentList = new ObservableCollection<Student>();
            using (var db = new dbDataContext())
            {
                var sqs = db.StudentQuizzes.Where(sq => sq.dbQuizId == quizId).ToList();
                foreach (var sq in sqs)
                {
                    foreach (var stu in db.Students)
                    {
                        bool testDone = false;
                        if (stu.dbStudentId == sq.dbStudentId)
                            testDone = true;
                        studentList.Add(new Student(stu) { TestDone = testDone });
                    }
                }
            }
            return studentList;
        }


        public List<dbQuiz> QuizsList()
        {
            using (var db = new dbDataContext())
            {
                return db.Quizes.ToList();
            }
        }
        public void DbRemoveUser(dbStudent Stu)
        {
            using (var db = new dbDataContext())
            {
                dbStudent stu2 = db.Students.Where(c => c.dbStudentId == Stu.dbStudentId).FirstOrDefault<dbStudent>();

                db.Students.Remove(stu2);
                db.SaveChanges();
            }
        }

        internal void SaveStudentQuiz(ObservableCollection<Student> sendoutList, dbQuiz targetQuiz)
        {
            using (var db = new dbDataContext())
            {
                foreach (var student in sendoutList)
                {
                    db.StudentQuizzes.Add(new dbStudentQuiz { dbStudentId = student.ID, dbQuizId = targetQuiz.dbQuizId });
                }
                db.Quizes.ToList().Single(q => q.dbQuizId == targetQuiz.dbQuizId).Feedback = targetQuiz.Feedback;
                db.SaveChanges();
            }
        }
    }
}
