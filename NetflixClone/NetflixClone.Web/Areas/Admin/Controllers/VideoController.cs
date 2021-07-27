using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Areas.Admin.Models.VideoViewModel;
using NetflixClone.Web.Controllers;
using NetflixClone.Web.Helpers;
using System;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController : BaseController
    {
        private readonly ILogger<VideoController> _logger;
        private readonly IFileUploadHelper _fileUploadHelper;

        public VideoController(
                UserManager<ApplicationUser> userManager,
                ILogger<VideoController> logger,
                IFileUploadHelper fileUploadHelper
                )
           : base(userManager)
        {
            _logger = logger;
            _fileUploadHelper = fileUploadHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new VideoCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VideoCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                var fileName = _fileUploadHelper.UploadFile(model.File);
                model.VideoUrl = fileName;
                model.CreateVideo();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message, ex);
            }

            return View(model);
        }
    }
}
