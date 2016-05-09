using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    class Quiz
    {
        public string Name { get; set; }
        public string Intro { get; set; }
        public int GradeG { get; set; }
        public int GradeVG { get; set; }
        public int TimeLimit { get; set; }
        public virtual ObservableCollection<Question> Questions { get; set; }
    }
}
