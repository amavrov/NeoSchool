using Microsoft.EntityFrameworkCore;
using NeoSchool.Data;
using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly NeoSchoolDbContext db;

        public MaterialService(NeoSchoolDbContext db)
        {
            this.db = db;
        }

        public string Delete(string VideoId)
        {
            throw new NotImplementedException();
        }



        public string Create(MaterialInputModel model)
        {
            //TODO: Validate model

            Material material = new Material()
            {
                Author = model.Author,
                Description = model.Description,
                Disciplines = model.Disciplines,
                ForTeachers = model.ForTeachers,
                Name = model.Name,
            };

            db.Materials.Add(material);
            db.SaveChanges();

            var result = $"You have successfully added the video {model.Name}!";
            return result;
        }

        public MaterialViewModel Details(int materialId)
        {
            Material materialFromDb = this.db.Materials
                                              .Where(mat => mat.Id == materialId)
                                              .Include(dbMat => dbMat.Author)
                                              .SingleOrDefault();

            MaterialViewModel material = new MaterialViewModel
            {
                Author = materialFromDb.Author,
                Description = materialFromDb.Description,
                Disciplines = materialFromDb.Disciplines,
                ForTeachers = materialFromDb.ForTeachers,
                Id = materialFromDb.Id,
                Name = materialFromDb.Name,
                Rating = materialFromDb.Rating,
            };

            return material;
        }

        public List<MaterialViewModel> GetAllMaterials()
        {

            // TODO: add pagination

            var materialList = db.Materials
                .Include(author => author.Author)
                .ToList()
                .Select(video =>
                {
                    return new MaterialViewModel
                    {
                        Id = video.Id,
                        Author = video.Author,
                        Description = video.Description,
                        Disciplines = video.Disciplines,
                        ForTeachers = video.ForTeachers,
                        Name = video.Name,
                    };
                }).ToList();

            return materialList;
        }

        public string GetMaterialId()
        {
            throw new NotImplementedException();
        }
    }
}
