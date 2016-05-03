using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitaltTestVerktygGrupp6Student.Database;

namespace DigitaltTestVerktygGrupp6Student.Model
{
    class RankingAlternative : Alternative
    {
        public RankingAlternative(dbAlternatives alt, Question question) : base(alt, question)
        {
        }
    }
}
