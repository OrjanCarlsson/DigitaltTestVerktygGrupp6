namespace DigitaltTestVerktygGrupp6Student.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbStudentQuizs
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dbStudentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dbQuizId { get; set; }

        public int Time { get; set; }

        public int Score { get; set; }

        public virtual dbQuizs dbQuizs { get; set; }

        public virtual dbStudents dbStudents { get; set; }
    }
}
