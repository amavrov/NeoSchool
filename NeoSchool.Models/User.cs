using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeoSchool.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UploadedVideos = new HashSet<VideoLesson>();
            this.UploadedMaterials = new HashSet<Material>();
            this.Comments = new HashSet<VideoLessonComment>();

        }

        public bool IsTeacher { get; set; }


        public HashSet<VideoLesson> UploadedVideos { get; set; }


        public HashSet<Material> UploadedMaterials { get; set; }

        public HashSet<VideoLessonComment> Comments { get; set; }




    }
}
