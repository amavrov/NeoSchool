using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class VideoLessonViewModel
    {
        public VideoLessonViewModel()
        {
            this.Comments = new HashSet<Comment>();
            this.Disciplines = new HashSet<Discipline>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int Rating { get; set; }

        public bool ForTeachers { get; set; }

        public User Author { get; set; }

        public HashSet<Comment> Comments { get; set; }

        public HashSet<Discipline> Disciplines { get; set; }

    }
}
