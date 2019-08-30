using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeoSchool.Models
{
    public class MaterialComment
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(140)]
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int MaterialId { get; set; }

        public Material Material { get; set; }
    }
}
