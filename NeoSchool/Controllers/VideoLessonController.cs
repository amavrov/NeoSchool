using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeoSchool.Models;
using NeoSchool.Services;

namespace NeoSchool.Controllers
{
    public class VideoLessonController : Controller
    {
        private readonly IVideoLessonService service;

        public VideoLessonController(IVideoLessonService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoLessonInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new VideoLessonInputModel());
            }

            service.Create(model);            

            return this.Redirect("/");

        }

        public async Task<IActionResult> ViewAll()
        {
            //var allVideos =

            return null;
        }

    }
}