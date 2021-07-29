using Autofac;
using Microsoft.AspNetCore.Http;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.VideoViewModel
{
    public class VideoCreateViewModel : AdminBaseModel
    {
        private readonly IVideoService _videoService;
        private readonly ICategoryService _categoryService;

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string VideoUrl { get; set; }

        [Required(ErrorMessage ="Category is required")]
        [Display(Name ="Category")]
        public int? CategoryId { get; set; }

        public IList<VideoCategory> CategoryList { get; set; }

        [Required]
        public IFormFile File { get; set; }

        public VideoCreateViewModel()
        {
            _videoService = Startup.AutofacContainer.Resolve<IVideoService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            CategoryList = new List<VideoCategory>();
        }

       public void CreateVideo()
        {
            _videoService.AddVideo(new Foundation.Entities.Video
            {
                Title = Title,
                Description = Description,
                Url = VideoUrl,
                ReleasedDate = DateTime.Now,
                CategoryId = CategoryId.Value
            });
        }

        public void LoadModelData()
        {
            CategoryList = _categoryService.CategoryList();
        }
    }
}
