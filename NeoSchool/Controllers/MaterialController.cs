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
        //

        //[HttpPost]
        //public async Task<IActionResult> Create(MaterialInputModel model)
        //{

        //    string pictureUrl = await this.cloudinaryService.UploadFileAsync(
        //        model.File,
        //        model.Name);

        //    ProductServiceModel productServiceModel = AutoMapper.Mapper.Map<ProductServiceModel>(productCreateInputModel);

        //    productServiceModel.Picture = pictureUrl;

        //    await this.productService.Create(productServiceModel);

        //    return this.Redirect("/");
        //}
        //
        [Authorize]
        public IActionResult ViewAll()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult MaterialDetails(int materialId)
        {
            int matId = int.Parse(this.Request.Path.ToString().Split('/').LastOrDefault());
            MaterialViewModel material = service.Details(matId);
            return this.View(material);
        }

        public IActionResult CommentCurrentMaterial(MaterialCommentInputModel comment)
        {
            
            service.CommentMaterial(comment);

            return Redirect("/Material/MaterialDetails/" + comment.MaterialId.ToString());
        }
    }
}