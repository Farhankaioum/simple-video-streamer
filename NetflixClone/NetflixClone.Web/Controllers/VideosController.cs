using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Models.VideoViewModel;
using System;
using System.Security.Claims;
using X.PagedList;
using NetflixClone.Foundation.Helpers;

namespace NetflixClone.Web.Controllers
{
    [Authorize(Roles = ConstantValue.SUBSCRIBE_USER_ROLE)]
    public class VideosController : BaseController
    {
        private readonly ILogger<VideosController> _logger;

        public VideosController(
            UserManager<ApplicationUser> userManager,
            ILogger<VideosController> logger)
            : base(userManager)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            var model = new VideoIndexViewModel();
            var pageNumber = page ?? 1;

            model.GetAllVideos();
            model.VideosWithPaging = model.VideoList.ToPagedList(pageNumber, 12);

            return View(model.VideosWithPaging);
        }

        public IActionResult Detail(Guid id)
        {
            var model = new VideoDetailViewModel();
            model.GetVideoById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ErrorSubmit(string videoId, string error, string duration = null)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest();

            try
            {
                var model = new VideoDetailViewModel();
                model.InsertPlayingError(new PlayingError { 
                    UserId = userId,
                    VideoId = videoId,
                    Error = error,
                    Duration = duration,
                    DateTime = DateTime.Now
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }

            return Json("ok");
        }
    }
}
