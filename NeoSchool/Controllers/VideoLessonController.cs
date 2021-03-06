﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<IActionResult> Create(VideoLessonInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new VideoLessonInputModel());
            }
            

            await service.Create(model);            

            return this.Redirect("/VideoLesson/ViewAll");

        }

        [Authorize]
        public async Task<IActionResult> CommentCurrentVideo(CommentInputModel comment)
        {
            await service.CommentVideo(comment);

            return Redirect("/VideoLesson/VideoDetails/" + comment.VideoLessonId.ToString());
        }


        [Authorize]
        public IActionResult ViewAll()
        {
            return this.View();
        }

        [Authorize]
        public async Task<IActionResult> VideoDetails(int videoId)
        {
            int vidId = int.Parse(this.Request.Path.ToString().Split('/').LastOrDefault());
            VideoLessonViewModel video = await service.Details(vidId);
            return this.View(video);
        }

    }
}