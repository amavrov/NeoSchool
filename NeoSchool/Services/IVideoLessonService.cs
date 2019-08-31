using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IVideoLessonService
    {
        Task<string> Create(VideoLessonInputModel model);

        List<VideoLessonViewModel> GetAllVideos();

        Task <string> Delete(string VideoId);

        Task <VideoLessonViewModel> GetVideoById(string videoId);

        string GetEmbeddingUrl(string url);


        Task <VideoLessonViewModel> Details(int videoId);

        string GetShortDescription(string fullDescription);

        Task <string> CommentVideo(CommentInputModel model);


    }
}
