﻿using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class MaterialCommentInputModel : IMapTo<MaterialComment>
    {
        public long Id { get; set; }

        [Required]
        [StringLength(140, ErrorMessage = "Comment should be between 3 and 140 characters long", MinimumLength = 3)]
        public string Text { get; set; }

        public User Author { get; set; }

        public int MaterialId { get; set; }

        public MaterialInputModel Material { get; set; }
    }
}
