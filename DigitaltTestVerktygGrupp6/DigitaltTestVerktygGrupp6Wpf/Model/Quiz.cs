﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitaltTestVerktygGrupp6Wpf.Model
{
    class Quiz
    {
        public int QuizId { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public int GradeG { get; set; }
        public int GradeVG { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}