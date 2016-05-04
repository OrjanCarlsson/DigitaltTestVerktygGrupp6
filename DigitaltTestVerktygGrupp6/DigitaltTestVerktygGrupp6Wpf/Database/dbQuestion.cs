using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Database
{
    public enum QuestionType
    {
        Single,
        Multi,
        Text,
        Rank
    }
    public class dbQuestion
    {
        public int dbQuestionId { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public int Points { get; set; }
        public dbQuiz Quiz { get; set; }
        public int dbQuizId { get; set; }
        public virtual ICollection<dbAlternative> Alternatives { get; set; }
    }
}
