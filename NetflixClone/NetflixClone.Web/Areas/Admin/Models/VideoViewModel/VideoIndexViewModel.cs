using Autofac;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Services;
using System;
using System.Collections.Generic;

namespace NetflixClone.Web.Areas.Admin.Models.VideoViewModel
{
    public class VideoIndexViewModel : AdminBaseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<VideoIndexViewModel> VideoList = new List<VideoIndexViewModel>();

        private readonly IVideoService _videoService;

        public VideoIndexViewModel()
        {
            _videoService = Startup.AutofacContainer.Resolve<IVideoService>();
        }

        public void LoadModelData()
        {
            var videoList = _videoService.VideoList();
            foreach(var video in videoList)
            {
                VideoList.Add(new VideoIndexViewModel { 
                    Id = video.Id,
                    Title = video.Title,
                    Description = video.Description,
                    ReleaseDate = video.ReleasedDate,
                    CategoryId = video.CategoryId,
                    VideoUrl = video.Url
                });
            }
        }

        public void DeleteVideo(Guid id)
        {
            var existingVideo = _videoService.GetVideoById(id);
            if (existingVideo == null)
                throw new NotFoundException("Video not found!");

            _videoService.DeleteVideo(existingVideo);
        }
    }
}
