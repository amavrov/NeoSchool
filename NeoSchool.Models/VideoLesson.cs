﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeoSchool.Models
{
    public class VideoLesson
    {
        public VideoLesson()
        {
            this.VideoLessonComments = new HashSet<VideoLessonComment>();
            this.Disciplines = new HashSet<Discipline>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int Rating { get; set; }

        public bool ForTeachers { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public HashSet<VideoLessonComment> VideoLessonComments { get; set; }

        public HashSet<Discipline> Disciplines { get; set; }

    }
}
