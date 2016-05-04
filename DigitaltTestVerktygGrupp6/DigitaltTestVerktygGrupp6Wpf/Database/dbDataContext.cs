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
            // modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

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
            IList<dbQuestion> defaultQuestions = new List<dbQuestion>();
            IList<dbStudentQuiz> defaultStudentQuizs = new List<dbStudentQuiz>();
            List<dbAlternative> defaultAlternatvies = new List<dbAlternative>();
            defaultStudentQuizs.Add(new dbStudentQuiz
            {
                dbStudentId = 1,
                dbQuizId = 1,
                Time = 5,
                Score = 120
            });
            

            defaultQuestions.Add(new dbQuestion
            {
                Text = "Välj det största talet",
                Type = QuestionType.Single.ToString(),
                Points = 10,
                Alternatives = new List<dbAlternative> { new dbAlternative{ Text = "2", IsCorrect = 0 }, new dbAlternative { Text = "3", IsCorrect = 0 },
                new dbAlternative { Text = "7", IsCorrect = 1 } }
            });
            defaultQuestions.Add(new dbQuestion
            {
                Text = "Vad är 2 + 2?",
                Type = QuestionType.Text.ToString(),
                Points = 5,
                Alternatives = new List<dbAlternative> { new dbAlternative { Text = "4", IsCorrect = 1 } }
            });
            defaultQuestions.Add(new dbQuestion
            {
                Text = "Välj de tal som är udda",
                Type = QuestionType.Multi.ToString(),
                Points = 15,
                Alternatives = new List<dbAlternative> { new dbAlternative{ Text = "3", IsCorrect = 1 }, new dbAlternative { Text = "4", IsCorrect = 0 },
                new dbAlternative { Text = "7", IsCorrect = 1 }, new dbAlternative {Text="8", IsCorrect=0 }
            }
            });
            defaultQuestions.Add(new dbQuestion
            {
                Text = "Sortera från störst till minst",
                Type = QuestionType.Rank.ToString(),
                Points = 20,
                Alternatives = new List<dbAlternative> { new dbAlternative{ Text = "11", IsCorrect = 3 }, new dbAlternative { Text = "13", IsCorrect = 2 },
                new dbAlternative { Text = "18", IsCorrect = 1 }, new dbAlternative {Text="24", IsCorrect=0 }
            }
            });

            defaultQuiz.Add(new dbQuiz
            {
                dbQuizId = 1,
                Name = "Matte",
                Intro = "Compare numbers",
                GradeG = 50,
                GradeVG = 70,
                TimeLimit = 100,
                StudentQuizes = defaultStudentQuizs,
                Questions = defaultQuestions
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

            defaultStudent.Add(new dbStudent
            {
                StudentQuizes = defaultStudentQuizs,
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
