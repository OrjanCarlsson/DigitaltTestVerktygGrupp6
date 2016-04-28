namespace DigitaltTestVerktygGrupp6Student.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quizs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quizs()
        {
            Questions = new HashSet<Questions>();
            StudentQuizs = new HashSet<StudentQuizs>();
        }

        [Key]
        public int QuizId { get; set; }

        public string Name { get; set; }

        public string Intro { get; set; }

        public int GradeG { get; set; }

        public int GradeVG { get; set; }

        public int TimeLimit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questions> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentQuizs> StudentQuizs { get; set; }
    }
}
