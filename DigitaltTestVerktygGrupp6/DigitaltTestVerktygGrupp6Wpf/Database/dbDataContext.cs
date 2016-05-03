using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Database
{
    public class dbDataContext : DbContext
    {
        
        public DbSet<dbAlternative> Alternatives { get; set; }
        public DbSet<dbQuestion> Questions { get; set; }
        public DbSet<dbQuiz> Quizes { get; set; }
        public DbSet<dbStudent> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            // Add any configuration or mapping stuff here
        }

        public void Seed(dbDataContext Context)
        {
#if DEBUG
            // Create my debug (testing) objects here
           
#endif

            // Normal seeding goes here
            IList<dbStudent> defaultStudent = new List<dbStudent>();
            IList<dbQuiz> defaultQuiz = new List<dbQuiz>();

            defaultStudent.Add(new dbStudent {
                dbStudentId = 1,
                FirstName = "Ottar",
                LastName = "Kallesson",
                UserName = "Stuff1",
                Password = "123",
                Email = "Ottar@stuff.se"
            });
            defaultStudent.Add(new dbStudent
            {
                dbStudentId = 2,
                FirstName = "Örjan",
                LastName = "Carlsson",
                UserName = "wohoo01",
                Password = "123",
                Email = "OrjanCool92@stuff.se"
            });
            defaultQuiz.Add(new dbQuiz
            {
                dbQuizId = 1,
                Name = "Quiz1",
                Intro = "Stuff123",
                GradeG = 50,
                GradeVG = 70,
                TimeLimit = 100
            });
            defaultQuiz.Add(new dbQuiz
            {
                dbQuizId = 2,
                Name = "Quiz2",
                Intro = "Stuff123",
                GradeG = 55,
                GradeVG = 75,
                TimeLimit = 120
            });
            foreach (dbStudent stu in defaultStudent)
                Context.Students.Add(stu);
            foreach (dbQuiz quiz in defaultQuiz)
                Context.Quizes.Add(quiz);

            Context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<dbDataContext>
        {
            protected override void Seed(dbDataContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<dbDataContext>
        {
            protected override void Seed(dbDataContext context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }
        static dbDataContext()
        {
#if DEBUG
           System.Data.Entity.Database.SetInitializer<dbDataContext>(new DropCreateIfChangeInitializer());

#else
        Database.SetInitializer<MyDbContext> (new CreateInitializer ());
#endif
        }


    }
   
}
