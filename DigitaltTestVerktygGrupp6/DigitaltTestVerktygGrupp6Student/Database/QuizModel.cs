namespace DigitaltTestVerktygGrupp6Student.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuizModel : DbContext
    {
        public QuizModel()
            : base("name=QuizModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<dbAlternatives> dbAlternatives { get; set; }
        public virtual DbSet<dbQuestions> dbQuestions { get; set; }
        public virtual DbSet<dbQuizs> dbQuizs { get; set; }
        public virtual DbSet<dbStudentQuizs> dbStudentQuizs { get; set; }
        public virtual DbSet<dbStudents> dbStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
