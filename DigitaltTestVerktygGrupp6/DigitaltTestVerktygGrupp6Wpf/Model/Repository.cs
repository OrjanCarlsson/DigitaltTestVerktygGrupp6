using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    public class Repository
    {
        public List<Student> StudentsList()
        {
            using (var db = new DataContext())
            {
                return db.Students.Include("Quizes").ToList();
            }
        }
    }
}
