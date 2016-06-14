namespace DigitaltTestVerktygGrupp6Student.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbQuizs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbQuizs()
        {
            dbQuestions = new HashSet<dbQuestions>();
            dbStudentQuizs = new HashSet<dbStudentQuizs>();
        }

        [Key]
        public int dbQuizId { get; set; }

        public string Name { get; set; }

        public string Intro { get; set; }

        public int GradeG { get; set; }

        public int GradeVG { get; set; }

        public int TimeLimit { get; set; }
        public bool Feedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbQuestions> dbQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbStudentQuizs> dbStudentQuizs { get; set; }
    }
}
