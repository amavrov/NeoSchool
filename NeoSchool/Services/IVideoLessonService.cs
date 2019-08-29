using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IVideoLessonService
    {
        string Create(VideoLessonInputModel model);

        List<VideoLessonViewModel> GetAllVideos();

        string Delete(string VideoId);

        VideoLessonViewModel GetVideoById(string videoId);

        string GetEmbeddingUrl(string url);


        VideoLessonViewModel Details(int videoId);

        string GetShortDescription(string fullDescription);

        string CommentVideo(CommentInputModel model);


    }
}
