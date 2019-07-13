﻿using NeoSchool.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class MaterialInputModel
    {
        public MaterialInputModel()
        {
            this.Disciplines = new HashSet<Discipline>();
            this.Comments = new HashSet<Comment>();
        }


        public MaterialType Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForTeachers { get; set; }

        public User Author { get; set; }

        public HashSet<Discipline> Disciplines { get; set; }

        public HashSet<Comment> Comments { get; set; }


    }
}