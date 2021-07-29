using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetflixClone.Foundation.Contexts;
using NetflixClone.Foundation.Entities;
using System.Security.Claims;

namespace NetflixClone.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
        }

        private void LoadUserInformation(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            Input = new InputModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Address = user.City,
                PhotoUrl = user.ImageUrl
            };
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string FullName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string PhotoUrl { get; set; }
        }

        public void OnGet()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            LoadUserInformation(userId);
        }
    }
}
