using Autofac;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Services;
using System;

namespace NetflixClone.Web.Models.VideoViewModel
{
    public class VideoDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }

        private readonly IVideoService _videoService;
        private readonly IPlayingErrorService _playingErrorService;

        public VideoDetailViewModel()
        {
            _videoService = Startup.AutofacContainer.Resolve<IVideoService>();
            _playingErrorService = Startup.AutofacContainer.Resolve<IPlayingErrorService>();
        }

        public void GetVideoById(Guid id)
        {
            var video = _videoService.GetVideoById(id);
            Id = video.Id;
            Title = video.Title;
            Description = video.Description;
            ReleaseDate = video.ReleasedDate;
            Url = video.Url;
            CategoryId = video.CategoryId;
        }

        public void InsertPlayingError(PlayingError error)
        {
            _playingErrorService.AddPlayingError(error);
        }

    }
}
