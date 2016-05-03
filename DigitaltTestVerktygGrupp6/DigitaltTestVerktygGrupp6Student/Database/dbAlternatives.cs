namespace DigitaltTestVerktygGrupp6Student.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbAlternatives
    {
        [Key]
        public int dbAlternativeId { get; set; }

        public string Text { get; set; }

        public int IsCorrect { get; set; }

        public int dbQuestionId { get; set; }

        public virtual dbQuestions dbQuestions { get; set; }
    }
}
