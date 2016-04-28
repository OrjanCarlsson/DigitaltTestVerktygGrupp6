namespace DigitaltTestVerktygGrupp6Student.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alternatives
    {
        [Key]
        public int AlternativeId { get; set; }

        public string Text { get; set; }

        public int IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public virtual Questions Questions { get; set; }
    }
}
