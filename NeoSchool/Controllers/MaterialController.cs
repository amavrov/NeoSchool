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
        private readonly ICloudinaryService cloudinaryService;

        public MaterialController(IMaterialService service, ICloudinaryService cloudinaryService)
        {
            this.service = service;
            this.cloudinaryService = cloudinaryService;
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<IActionResult> Create(MaterialInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new MaterialInputModel());
            }

            await service.Create(model);

            return this.Redirect("/Material/ViewAll");

        }

        [Authorize]
        public IActionResult ViewAll()
        {
            return this.View();
        }

        [Authorize]
        public async Task<IActionResult> MaterialDetails(int materialId)
        {
            int matId = int.Parse(this.Request.Path.ToString().Split('/').LastOrDefault());
            MaterialViewModel material = await service.Details(matId);
            return this.View(material);
        }

        [Authorize]
        public async Task<IActionResult> CommentCurrentMaterial(MaterialCommentInputModel comment)
        {
            
            await service.CommentMaterial(comment);

            return Redirect("/Material/MaterialDetails/" + comment.MaterialId.ToString());
        }
    }
}