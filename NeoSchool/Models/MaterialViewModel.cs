using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class MaterialViewModel : IMapFrom<Material>
    {

        public MaterialViewModel()
        {
            this.Disciplines = new HashSet<Discipline>();
            this.Comments = new HashSet<CommentViewModel>();

        }

        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public bool ForTeachers { get; set; }

        public string FileLink { get; set; }

        public User Author { get; set; }

        public HashSet<Discipline> Disciplines { get; set; }

        public HashSet<CommentViewModel> Comments { get; set; }



    }
}
