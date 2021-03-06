using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Foundation.Entities;

namespace NetflixClone.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> UserManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }
    }
}
