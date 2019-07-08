using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeoSchool.Data;
using NeoSchool.Models;

namespace NeoSchool.Services
{
    public class VideoLessonService : IVideoLessonService
    {
        private readonly NeoSchoolDbContext db;

        public VideoLessonService(NeoSchoolDbContext db)
        {
            this.db = db;
        }

        public string Delete(string VideoId)
        {
            throw new NotImplementedException();
        }

        public string GetVideoId()
        {
            throw new NotImplementedException();
        }

        public string Create(VideoLessonInputModel model)
        {
            //TODO: Validate model

            VideoLesson video = new VideoLesson()
            {
                Author = model.Author,
                Description = model.Description,
                Disciplines = model.Disciplines,
                ForTeachers = model.ForTeachers,
                Name = model.Name,
                Url = model.Url,
                Rating = 0,
                Comments = new HashSet<Comment>()
            };

            db.VideoLessons.Add(video);
            db.SaveChanges();

            var result = $"You have successfully added the video {model.Name}!";
            return result;
        }

        public VideoLessonViewModel Details(int videoId)
        {
            VideoLesson videoLesson = this.db.VideoLessons
                                              .Where(DbVideo => DbVideo.Id == videoId)
                                              .Include(DbVideo => DbVideo.Author)
                                              .SingleOrDefault();

            VideoLessonViewModel video = new VideoLessonViewModel
            {
                Author = videoLesson.Author,
                Description = videoLesson.Description,
                Disciplines = videoLesson.Disciplines,
                ForTeachers = videoLesson.ForTeachers,
                Id = videoLesson.Id,
                Name = videoLesson.Name,
                Rating = videoLesson.Rating,
                Url = videoLesson.Url
            };

            return video;
        }

        public List<VideoLessonViewModel> GetAllVideos()
        {

            // TODO: add pagination

            var videoList = db.VideoLessons
                .Include(author => author.Author)
                .ToList()
                .Select(video =>
                {
                    return new VideoLessonViewModel
                    {
                        Id = video.Id,
                        Author = video.Author,
                        Description = video.Description,
                        Disciplines = video.Disciplines,
                        ForTeachers = video.ForTeachers,
                        Name = video.Name,
                        Url = video.Url
                    };
                }).ToList();

            return videoList;
        }



    }

}
