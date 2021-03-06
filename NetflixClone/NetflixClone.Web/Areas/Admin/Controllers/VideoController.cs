using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using foundationHelper = NetflixClone.Foundation.Helpers;
using NetflixClone.Web.Areas.Admin.Models.VideoViewModel;
using NetflixClone.Web.Controllers;
using System;
using NetflixClone.Web.Helpers;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = foundationHelper.ConstantValue.ADMIN_USER_ROLE)]
    public class VideoController : BaseController
    {
        private readonly ILogger<VideoController> _logger;
        private readonly IFileUploadHelper _fileUploadHelper;
        private readonly INotyfService _notyf;

        public VideoController(
                UserManager<ApplicationUser> userManager,
                ILogger<VideoController> logger,
                IFileUploadHelper fileUploadHelper,
                INotyfService notyf
                )
           : base(userManager)
        {
            _logger = logger;
            _fileUploadHelper = fileUploadHelper;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            var model = new VideoIndexViewModel();
            model.LoadModelData();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new VideoCreateViewModel();
            model.LoadModelData();
            return View(model);
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VideoCreateViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                model.LoadModelData();
                return View(model);
            } 

            try
            {
                var fileName = _fileUploadHelper.UploadFile(model.File);
                model.VideoUrl = fileName;
                model.CreateVideo();
                _notyf.Success("Added successfully!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message, ex);
                _notyf.Error(ex.Message);
            }

            model.LoadModelData();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var model = new VideoEditViewModel();
            model.GetVideoById(id);
            model.LoadModelData();
            return View(model);
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VideoEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                if(model.File.Length > 0)
                {
                    var fileName = _fileUploadHelper.UploadFile(model.File);
                    model.VideoUrl = fileName;
                }
                
                model.EditVideo();
                _notyf.Success("Update successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                _notyf.Error(ex.Message);
            }

            model.LoadModelData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = new VideoIndexViewModel();
                model.DeleteVideo(id);
                _notyf.Success("Delete successfully!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                _notyf.Error(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
