using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Database
{
    public class dbQuiz
    {
        public int dbQuizId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public int GradeG { get; set; }
        public int GradeVG { get; set; }
        public int TimeLimit { get; set; }  
        public virtual ICollection<dbQuestion> Questions { get; set; }
        public virtual ICollection<dbStudentQuiz> StudentQuizes { get; set; }

    }
}
