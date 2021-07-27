using Autofac;
using Microsoft.AspNetCore.Http;
using NetflixClone.Foundation.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.VideoViewModel
{
    public class VideoCreateViewModel
    {
        private readonly IVideoService _videoService;

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string VideoUrl { get; set; }

        [Required]
        public IFormFile File { get; set; }

        public VideoCreateViewModel()
        {
            _videoService = Startup.AutofacContainer.Resolve<IVideoService>();
        }

       public void CreateVideo()
        {
            _videoService.AddVideo(new Foundation.Entities.Video
            {
                Title = Title,
                Description = Description,
                Url = VideoUrl
            });
        }
    }
}
