﻿using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class CommentViewModel : IMapFrom<VideoLessonComment>
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public User Author { get; set; }

        public int VideoLessonId { get; set; }

        public VideoLessonInputModel VideoLesson { get; set; }
    }
}
