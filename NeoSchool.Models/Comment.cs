using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSchool.Models
{
    public class Comment
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public User Author { get; set; }

        public Material Material { get; set; }

        public VideoLesson VideoLesson { get; set; }


    }
}
