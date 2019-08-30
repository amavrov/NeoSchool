using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeoSchool.Models
{
    public class Material
    {
        public Material()
        {
            this.Disciplines = new HashSet<Discipline>();
            this.MaterialComments = new HashSet<MaterialComment>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }


        public bool ForTeachers { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public string FileLink { get; set; }

        public HashSet<Discipline> Disciplines { get; set; }

        public HashSet<MaterialComment> MaterialComments { get; set; }

    }
}
