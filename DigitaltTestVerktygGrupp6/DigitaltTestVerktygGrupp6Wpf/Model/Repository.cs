﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Wpf.Database;

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
            //using (var db = new dbDataContext())
            //{
            //    var query = from quiz in db.Quizes
            //                where quiz.StudentQuizes.Any(c => c.dbStudentId == 1)
            //                select quiz;

            //    return query.ToList();
            //}
            return null;
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
    }
}
