using Microsoft.AspNetCore.Http;
using NeoSchool.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Models
{
    public class MaterialInputModel : IMapTo<Material>
    {

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForTeachers { get; set; }

        public IFormFile File { get; set; }

        public User Author { get; set; }

        public string DisciplineName { get; set; }

        public string Grade { get; set; }




    }
}
