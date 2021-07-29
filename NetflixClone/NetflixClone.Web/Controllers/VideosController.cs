using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Models.VideoViewModel;
using X.PagedList;

namespace NetflixClone.Web.Controllers
{
    public class VideosController : BaseController
    {
        public VideosController(UserManager<ApplicationUser> userManager)
            : base(userManager)
        {

        }

        public IActionResult Index(int? page)
        {
            var model = new VideoIndexViewModel();
            var pageNumber = page ?? 1;

            model.GetAllVideos();
            model.VideosWithPaging = model.VideoList.ToPagedList(pageNumber, 12);

            return View(model.VideosWithPaging);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
