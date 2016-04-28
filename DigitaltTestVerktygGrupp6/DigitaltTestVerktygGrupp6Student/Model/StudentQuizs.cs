namespace DigitaltTestVerktygGrupp6Student.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentQuizs
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuizId { get; set; }

        public int Time { get; set; }

        public int Score { get; set; }

        public virtual Quizs Quizs { get; set; }

        public virtual Students Students { get; set; }
    }
}
