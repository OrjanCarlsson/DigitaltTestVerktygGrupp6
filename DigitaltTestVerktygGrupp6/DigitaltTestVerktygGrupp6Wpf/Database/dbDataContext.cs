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

    }
}
