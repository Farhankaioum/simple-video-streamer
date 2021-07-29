using Autofac;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Services;
using System.Collections.Generic;

namespace NetflixClone.Web.Models.VideoViewModel
{
    public class VideoIndexViewModel
    {
        private readonly IVideoService _videoService;

        public X.PagedList.IPagedList<Video> VideosWithPaging { get; set; }

        public IList<Video> VideoList { get; set; }

        public VideoIndexViewModel()
        {
            _videoService = Startup.AutofacContainer.Resolve<IVideoService>();
        }

        public void GetAllVideos()
        {
            VideoList = _videoService.VideoList();
        }
    }
}
