using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeoSchool.Models;
using NeoSchool.Services;

namespace NeoSchool.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService service;

        public MaterialController(IMaterialService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public IActionResult Create(MaterialInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new MaterialInputModel());
            }

            service.Create(model);

            return this.Redirect("/");

        }

        [Authorize]
        public IActionResult ViewAll()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult VideoDetails(VideoLessonViewModel model)
        {
            return this.View(model);
        }
    }
}