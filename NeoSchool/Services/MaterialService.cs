using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NeoSchool.Data;
using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly NeoSchoolDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICloudinaryService cloudinaryService;

        public MaterialService(NeoSchoolDbContext db, IHttpContextAccessor httpContextAccessor, ICloudinaryService cloudinaryService)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
            this.cloudinaryService = cloudinaryService;
        }

        public string Delete(string VideoId)
        {
            throw new NotImplementedException();
        }



        public async Task<string> Create(MaterialInputModel model)
        {
            //TODO: Validate model
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string fileUrl = await this.cloudinaryService.UploadFileAsync(model.File, model.Name);
            string type = model.File.FileName.Split('.').LastOrDefault().ToString();

            Material material = new Material()
            {
                AuthorId = userId,
                Description = model.Description,
                Disciplines = model.Disciplines,
                ForTeachers = model.ForTeachers,
                Name = model.Name,
                FileLink = fileUrl,
                Type = type,
                MaterialComments = new HashSet<MaterialComment>()

            };

            ;
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
            var commentsFromDb = this.db.MaterialComments.Where(x => x.MaterialId == materialId).ToHashSet();

            var comments = new HashSet<CommentViewModel>();

            foreach (var comm in commentsFromDb)
            {
                CommentViewModel commView = new CommentViewModel
                {
                    Author = comm.Author,
                    Text = comm.Text,
                    VideoLessonId = comm.MaterialId
                };
                comments.Add(commView);
            }

            MaterialViewModel material = new MaterialViewModel
            {
                Author = materialFromDb.Author,
                Description = materialFromDb.Description,
                Disciplines = materialFromDb.Disciplines,
                ForTeachers = materialFromDb.ForTeachers,
                Id = materialFromDb.Id,
                Name = materialFromDb.Name,
                Rating = materialFromDb.Rating,
                FileLink = materialFromDb.FileLink,
                Comments = comments

            };

            return material;
        }

        public List<MaterialViewModel> GetAllMaterials()
        {

            // TODO: add pagination

            var materialList = db.Materials
                .Include(author => author.Author)
                .ToList()
                .Select(material =>
                {
                    return new MaterialViewModel
                    {
                        Id = material.Id,
                        Author = material.Author,
                        Description = material.Description,
                        Disciplines = material.Disciplines,
                        ForTeachers = material.ForTeachers,
                        Name = material.Name,
                        FileLink = material.FileLink

                    };
                }).ToList();

            return materialList;
        }

        public string GetMaterialId()
        {
            throw new NotImplementedException();
        }

        public string GetShortDescription(string fullDescription)
        {
            string shortDescription;

            if (fullDescription.Length > 52)
            {
                shortDescription = fullDescription.Substring(0, 52) + "... Read more";
            }
            else
            {
                shortDescription = fullDescription + "... Read more";

            }

            return shortDescription;
        }
        public string CommentMaterial(MaterialCommentInputModel model)
        {
            //TODO: Validate model
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            MaterialComment comment = new MaterialComment()
            {
                Text = model.Text,
                AuthorId = userId,
                MaterialId = model.MaterialId
            };

            db.MaterialComments.Add(comment);
            db.SaveChanges();

            var result = $"You have successfully made a comment!";
            return result;
        }
    }
}
