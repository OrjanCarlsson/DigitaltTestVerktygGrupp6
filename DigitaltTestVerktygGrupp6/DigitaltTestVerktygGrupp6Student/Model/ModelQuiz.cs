namespace DigitaltTestVerktygGrupp6Student.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelQuiz : DbContext
    {
        public ModelQuiz()
            : base("name=ModelQuiz")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Alternatives> Alternatives { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Quizs> Quizs { get; set; }
        public virtual DbSet<StudentQuizs> StudentQuizs { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
