using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Helpers;
using NetflixClone.Web.Areas.Admin.Models.HomeViewModel;
using NetflixClone.Web.Controllers;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ConstantValue.ADMIN_USER_ROLE)]
    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager) 
            : base(userManager)
        {

        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            return View(model);
        }
    }
}
