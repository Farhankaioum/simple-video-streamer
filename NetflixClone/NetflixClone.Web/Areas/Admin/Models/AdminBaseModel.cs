using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetflixClone.Foundation.Entities;
using System;

namespace NetflixClone.Web.Areas.Admin.Models
{
    public class AdminBaseModel
    {
        protected readonly UserManager<ApplicationUser> UserManager;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        public UserModel UserModel { get; set; }
        public string ActionUrl { get; set; }

        public AdminBaseModel(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            UserManager = userManager;
            HttpContextAccessor = httpContextAccessor;
            LoadModel();
        }

        public AdminBaseModel()
        {
            UserManager = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
            HttpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            LoadModel();
        }

        public void LoadModel()
        {
            var user = UserManager.GetUserAsync(HttpContextAccessor.HttpContext.User).Result;

            if (user != null)
                SetProperties(user);
            else
                throw new ArgumentNullException("User info not found");
        }

        private void SetProperties(ApplicationUser user)
        {
            UserModel = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.FullName,
                ImageUrl = user.ImageUrl,
            };
        }
    }
}
