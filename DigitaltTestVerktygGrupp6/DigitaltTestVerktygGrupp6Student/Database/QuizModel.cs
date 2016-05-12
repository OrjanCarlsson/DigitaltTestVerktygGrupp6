namespace DigitaltTestVerktygGrupp6Student.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuizModel : DbContext
    {
        public QuizModel()
            
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + "QuizDatabase.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework"; 
            Database.Connection.ConnectionString = connectionString;
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
