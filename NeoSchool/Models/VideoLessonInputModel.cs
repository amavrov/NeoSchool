using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class VideoLessonInputModel : IMapTo<VideoLesson>
    {

        public VideoLessonInputModel()
        {
            this.Disciplines = new HashSet<Discipline>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public bool ForTeachers { get; set; }

        public User Author { get; set; }

        // TODO Add requred to Disciplines
        public HashSet<Discipline> Disciplines { get; set; }
    }
}
