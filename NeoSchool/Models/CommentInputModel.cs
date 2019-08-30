using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class CommentInputModel : IMapTo<VideoLessonComment>
    {
        public long Id { get; set; }

        [Required]
        [StringLength(140, ErrorMessage ="Comment should be between 3 and 140 characters long", MinimumLength = 3)]
        public string Text { get; set; }

        public User Author { get; set; }

        public int VideoLessonId { get; set; }

        public VideoLessonInputModel VideoLesson { get; set; }
    }
}
