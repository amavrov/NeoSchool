using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSchool.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        public string DisciplineName { get; set; }

        public string Grade { get; set; }

        public Material Material { get; set; }

        public VideoLesson VideoLesson { get; set; }

    }
}
