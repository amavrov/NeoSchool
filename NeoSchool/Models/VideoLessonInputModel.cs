using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class VideoLessonInputModel : IMapTo<VideoLesson>
    {
        [Required]
        [StringLength(50 , ErrorMessage = "Name should be between 3 and 50 characters long", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Description should be between 3 and 1000 characters long", MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public bool ForTeachers { get; set; }

        public User Author { get; set; }

        public string DisciplineName { get; set; }

        public string Grade { get; set; }
    }
}
