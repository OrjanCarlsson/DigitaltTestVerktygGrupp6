using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Wpf.Database;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    public class Quizs
    {
        public int dbQuizId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public int GradeG { get; set; }
        public int GradeVG { get; set; }
        public int TimeLimit { get; set; }
        public bool Feedback { get; set; }

        public string FinalGrade { get; set; }
        public int TotalPoints { get; set; }

        public Quizs(dbQuiz quiz, dbStudentQuiz studetquiz)
        {
            Name = quiz.Name;
            Intro = quiz.Intro;
            GradeG = quiz.GradeG;
            GradeVG = quiz.GradeVG;
            TimeLimit = quiz.TimeLimit;
            Feedback = quiz.Feedback;
            foreach (var item in quiz.Questions)
            {
                TotalPoints += item.Points;
            }

            if (studetquiz.Score < TotalPoints * (GradeG / 100) )
            {
                FinalGrade = "IG";
            }
            else if (studetquiz.Score >= TotalPoints * (GradeVG / 100))
            {
                FinalGrade = "VG";
            }
            else
            {
                FinalGrade = "G";
            }

        }

    }
}
