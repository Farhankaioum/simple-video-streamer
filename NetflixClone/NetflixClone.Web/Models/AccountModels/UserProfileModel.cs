using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Models.AccountModels
{
    public class UserProfileModel
    {
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }
        [Display(Name = "Full Name: ")]
        public string FullName { get; set; }
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Display(Name = "Password: ")]
        public string Password { get; set; }
        [Display(Name = "Profile Image: ")]
        public string ImageUrl { get; set; }
    }
}