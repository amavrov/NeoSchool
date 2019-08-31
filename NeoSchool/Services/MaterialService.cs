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
        private readonly IDisciplineService disciplineService;

        public MaterialService(NeoSchoolDbContext db, IHttpContextAccessor httpContextAccessor, ICloudinaryService cloudinaryService, IDisciplineService disciplineService)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
            this.cloudinaryService = cloudinaryService;
            this.disciplineService = disciplineService;
        }

        public Task<string> Delete(string VideoId)
        {
            throw new NotImplementedException();
        }



        public async Task<string> Create(MaterialInputModel model)
        {
            //TODO: Validate model
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string fileUrl = await this.cloudinaryService.UploadFileAsync(model.File, model.Name);

            Material material = new Material()
            {
                AuthorId = userId,
                Description = model.Description,
                ForTeachers = model.ForTeachers,
                Name = model.Name,
                FileLink = fileUrl,
                MaterialComments = new HashSet<MaterialComment>()
            };

            if (model.DisciplineName != null && model.Grade != null)
            {
                var disc = await disciplineService.CreateDiscipline(model.DisciplineName, model.Grade);
                material.Disciplines.Add(disc);
            }

            db.Materials.Add(material);
            await db.SaveChangesAsync();

            var result = $"You have successfully added the video {model.Name}!";
            return result;
        }

        public async Task<MaterialViewModel> Details(int materialId)
        {
            Material materialFromDb = await this.db.Materials
                                              .Where(mat => mat.Id == materialId)
                                              .Include(dbMat => dbMat.Author)
                                              .Include(dbMat => dbMat.Disciplines)
                                              .SingleOrDefaultAsync();
            var commentsFromDb = this.db.MaterialComments.Where(x => x.MaterialId == materialId).Include(x => x.Author).ToHashSet();

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
                FileLink = materialFromDb.FileLink,
                Comments = comments

            };

            return material;
        }

        public List<MaterialViewModel> GetAllMaterials()
        {

            var materialList = db.Materials
                .Include(author => author.Author)
                .Include(d => d.Disciplines)
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

        public Task<string> GetMaterialId()
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
        public async Task<string> CommentMaterial(MaterialCommentInputModel model)
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
            await db.SaveChangesAsync();

            var result = $"You have successfully made a comment!";
            return result;
        }
    }
}
