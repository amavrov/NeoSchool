using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoSchool.Data;
using NeoSchool.Models;
using NeoSchool.Services;

namespace NeoSchool.Controllers
{
    public class SearchController : Controller
    {
        private readonly NeoSchoolDbContext db;
        private readonly IVideoLessonService videoLessonService;
        private readonly IMaterialService materialService;

        public SearchController(NeoSchoolDbContext db, IVideoLessonService videoLessonService, IMaterialService materialService)
        {
            this.db = db;
            this.videoLessonService = videoLessonService;
            this.materialService = materialService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult SearchAll()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult SearchAll(SearchModel model)
        {
            var videos = videoLessonService.GetAllVideos();

            foreach (var video in videos.Where(x => x.Disciplines.ToHashSet().Count != 0))
            {
                foreach (var item in video.Disciplines)
                {
                    var a = item.DisciplineName;
                    if (item.Grade == model.Grade && item.DisciplineName == model.DisciplineName)
                    {
                        model.VideoIdsAndNames.Add(new KeyValuePair<string, string>($"{video.Id}", $"{video.Name}"));
                    }
                }
            }

            var materials = materialService.GetAllMaterials();

            foreach (var material in materials.Where(x => x.Disciplines.ToHashSet().Count != 0))
            {
                foreach (var item in material.Disciplines)
                {
                    var a = item.DisciplineName;
                    if (item.Grade == model.Grade && item.DisciplineName == model.DisciplineName)
                    {
                        model.MaterialIdsAndNames.Add(new KeyValuePair<string, string>($"{material.Id}", $"{material.Name}"));
                    }
                }
            }
            return this.View("SearchResult", model);
        }

        [Authorize]
        public IActionResult GetAllForTeachers()
        {
            SearchModel model = new SearchModel();

            var videos = videoLessonService.GetAllVideos().Where(x => x.ForTeachers);
            var materials = materialService.GetAllMaterials().Where(x => x.ForTeachers);

            foreach (var video in videos)
            {
                model.VideoIdsAndNames.Add(new KeyValuePair<string, string>($"{video.Id}", $"{video.Name}"));
            }

            foreach (var material in materials)
            {
                model.MaterialIdsAndNames.Add(new KeyValuePair<string, string>($"{material.Id}", $"{material.Name}"));
            }

            return View("SearchResult", model);
        }
    }
}