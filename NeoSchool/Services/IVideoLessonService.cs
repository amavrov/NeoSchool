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

        string GetVideoId();

        VideoLessonViewModel Details(int videoId);
        
    }
}
