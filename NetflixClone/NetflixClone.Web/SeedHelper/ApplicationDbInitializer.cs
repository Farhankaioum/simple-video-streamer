using Microsoft.AspNetCore.Identity;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Helpers;

namespace NetflixClone.Web.SeedHelper
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            string userName = "adminuser@gmail.com";
            string password = "Admin123@@";

            if (userManager.FindByEmailAsync(userName).Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "adminuser@gmail.com",
                    Email = "adminuser@gmail.com",
                    FullName = "Admin"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ConstantValue.ADMIN_USER_ROLE).Wait();
                }
            }
        }
    }
}
