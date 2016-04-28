namespace DigitaltTestVerktygGrupp6Student.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Questions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questions()
        {
            Alternatives = new HashSet<Alternatives>();
        }

        [Key]
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public int Type { get; set; }

        public string Image { get; set; }

        public int Points { get; set; }

        public int QuizId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alternatives> Alternatives { get; set; }

        public virtual Quizs Quizs { get; set; }
    }
}
