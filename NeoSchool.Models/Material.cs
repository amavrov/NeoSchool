using System;
using System.Collections.Generic;
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

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public bool ForTeachers { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public string FileLink { get; set; }

        public HashSet<Discipline> Disciplines { get; set; }

        public HashSet<MaterialComment> MaterialComments { get; set; }

    }
}
