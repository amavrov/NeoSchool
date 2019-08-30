using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeoSchool.Data;
using NeoSchool.Models;
using NeoSchool.Services.Mapping;

namespace NeoSchool.Services
{
    public class VideoLessonService : IVideoLessonService
    {
        private readonly NeoSchoolDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDisciplineService disciplineService;

        public VideoLessonService(NeoSchoolDbContext db, IHttpContextAccessor httpContextAccessor, IDisciplineService disciplineService)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
            this.disciplineService = disciplineService;
        }

        public string Delete(string VideoId)
        {
            throw new NotImplementedException();
        }

        public VideoLessonViewModel GetVideoById(string videoId)
        {
            throw new NotImplementedException();
        }

        public string Create(VideoLessonInputModel model)
        {
            //TODO: Validate model
            VideoLesson video = Mapper.Map<VideoLesson>(model);
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            video.AuthorId = userId;

            if (model.DisciplineName != null && model.Grade != null)
            {
                var disc = disciplineService.CreateDiscipline(model.DisciplineName, model.Grade);
                video.Disciplines.Add(disc);
            }

            #region Old Manual Mapping
            //VideoLesson video = new VideoLesson()
            //{
            //    AuthorId = userId,
            //    Description = model.Description,
            //    Disciplines = model.Disciplines,
            //    ForTeachers = model.ForTeachers,
            //    Name = model.Name,
            //    Url = model.Url,
            //    Rating = 0,
            //    VideoLessonComments = new HashSet<VideoLessonComment>()

            //};
            #endregion

            db.VideoLessons.Add(video);
            db.SaveChanges();

            var result = $"You have successfully added the video {model.Name}!";
            return result;
        }

        public string CommentVideo(CommentInputModel model)
        {
            //TODO: Validate model
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User author = db.Users.FirstOrDefault(x => x.Id == userId);

            VideoLessonComment comment = new VideoLessonComment()
            {
                Text = model.Text,
                AuthorId = userId,
                VideoLessonId = model.VideoLessonId,
                Author = author
            };

            db.VideoLessonComments.Add(comment);
            db.SaveChanges();

            var result = $"You have successfully made a comment!";
            return result;
        }

        public VideoLessonViewModel Details(int videoId)
        {
            var commentsFromDb = this.db.VideoLessonComments.Where(x => x.VideoLessonId == videoId).Include(x => x.Author).ToHashSet();

            VideoLesson videoLesson = this.db.VideoLessons
                                              .Where(DbVideo => DbVideo.Id == videoId)
                                              .Include(DbVideo => DbVideo.Author)
                                              .Include(DbVideo => DbVideo.Disciplines)
                                              .SingleOrDefault();

            var comments = new HashSet<CommentViewModel>();

            foreach (var comm in commentsFromDb)
            {
                CommentViewModel commView = new CommentViewModel
                {
                    Author = comm.Author,
                    Text = comm.Text,
                    VideoLessonId = comm.VideoLessonId
                };
                comments.Add(commView);
            }

            VideoLessonViewModel video = new VideoLessonViewModel
            {
                Author = videoLesson.Author,
                Description = videoLesson.Description,
                Disciplines = videoLesson.Disciplines,
                ForTeachers = videoLesson.ForTeachers,
                Id = videoLesson.Id,
                Name = videoLesson.Name,
                Rating = videoLesson.Rating,
                Url = videoLesson.Url,
                Comments = comments

            };


            return video;
        }

        public List<VideoLessonViewModel> GetAllVideos()
        {
            var videoList = db.VideoLessons.Include(x => x.Disciplines).To<VideoLessonViewModel>().ToList();

            #region Old Manual Mapping
            //var videoList = db.VideoLessons
            //    .Include(author => author.Author)
            //    .ToList()
            //    .Select(video =>
            //    {
            //        return new VideoLessonViewModel
            //        {
            //            Id = video.Id,
            //            Author = video.Author,
            //            Description = video.Description,
            //            Disciplines = video.Disciplines,
            //            ForTeachers = video.ForTeachers,
            //            Name = video.Name,
            //            Url = video.Url
            //        };
            //    }).ToList();
            #endregion

            return videoList;
        }

        public string GetEmbeddingUrl(string url)
        {
            var splittedUrl = url.Split('=', '&');
            var youTubeId = splittedUrl[1];
            string finalUrl = "https:" + "//youtube.com/embed/" + youTubeId;
            return finalUrl;
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
    }

}
