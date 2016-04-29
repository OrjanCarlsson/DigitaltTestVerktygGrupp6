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
                return db.Students.ToList();
            }
        }
        public void DbRemoveUser(int Stu)
        {
            using (var db = new DataContext())
            {
                Student stu2 = db.Students.Where(c => c.StudentId == Stu).FirstOrDefault<Student>();


                db.Students.Remove(stu2);
                db.SaveChanges();
            }
        }
    }
}
