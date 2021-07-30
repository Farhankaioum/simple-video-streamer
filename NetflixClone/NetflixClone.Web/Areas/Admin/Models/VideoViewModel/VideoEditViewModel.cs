using Autofac;
using Microsoft.AspNetCore.Http;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.VideoViewModel
{
    public class VideoEditViewModel : AdminBaseModel
    {
        private readonly IVideoService _videoService;
        private readonly ICategoryService _categoryService;

        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string VideoUrl { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IList<VideoCategory> CategoryList { get; set; }

        public IFormFile File { get; set; }

        public VideoEditViewModel()
        {
            _videoService = Startup.AutofacContainer.Resolve<IVideoService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            CategoryList = new List<VideoCategory>();
        }

        public void EditVideo()
        {
            var existingVideo = _videoService.GetVideoById(Id);
            if (existingVideo == null)
                throw new NotFoundException("Video not found!");

            existingVideo.Title = Title;
            existingVideo.Description = Description;
            existingVideo.CategoryId = CategoryId;
            existingVideo.Url = VideoUrl;

            _videoService.UpdateVideo(existingVideo);
        }

        public void GetVideoById(Guid id)
        {
           var existingVideo = _videoService.GetVideoById(id);
            if (existingVideo == null)
                throw new NotFoundException("Video not found!");

            Id = existingVideo.Id;
            Title = existingVideo.Title;
            Description = existingVideo.Description;
            CategoryId = existingVideo.CategoryId;
            VideoUrl = existingVideo.Url;
        }

        public void LoadModelData()
        {
            CategoryList = _categoryService.CategoryList();
        }
    }
}
