using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeoSchool.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string DisciplineName { get; set; }

        [MaxLength(20)]
        public string Grade { get; set; }

        public Material Material { get; set; }

        public VideoLesson VideoLesson { get; set; }

    }
}
