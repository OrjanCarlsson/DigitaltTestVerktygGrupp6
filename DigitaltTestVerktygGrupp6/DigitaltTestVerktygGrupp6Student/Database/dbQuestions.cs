namespace DigitaltTestVerktygGrupp6Student.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbQuestions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbQuestions()
        {
            dbAlternatives = new HashSet<dbAlternatives>();
        }

        [Key]
        public int dbQuestionId { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public int Points { get; set; }

        public int dbQuizId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbAlternatives> dbAlternatives { get; set; }

        public virtual dbQuizs dbQuizs { get; set; }
    }
}
