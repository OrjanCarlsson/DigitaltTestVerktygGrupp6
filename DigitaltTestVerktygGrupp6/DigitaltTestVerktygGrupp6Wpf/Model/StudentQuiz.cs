using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    public class StudentQuiz
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        [Key, Column(Order = 1)]
        public int QuizId { get; set; }

        public virtual Student student { get; set; }
        public virtual Quiz quiz { get; set; }

        public int Time { get; set; }
        public int Score { get; set; }
    }
}
