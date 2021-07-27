using NetflixClone.Foundation.Entities;
using System;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Services
{
    public interface IVideoService
    {
        void AddVideo(Video video);
        IList<Video> VideoList();
        Video GetVideoById(Guid id);
        void UpdateVideo(Video video);
        void DeleteVideo(Video video);
    }
}
