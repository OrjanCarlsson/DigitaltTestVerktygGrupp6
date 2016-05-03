using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Database
{
    public class dbStudentQuiz
    {
        [Key, Column(Order = 0)]
        public int dbStudentId { get; set; }
        [Key, Column(Order = 1)]
        public int dbQuizId { get; set; }

        public virtual dbStudent student { get; set; }
        public virtual dbQuiz quiz { get; set; }

        public int Time { get; set; }
        public int Score { get; set; }
    }
}
