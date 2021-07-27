using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager) 
            : base(userManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
