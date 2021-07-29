using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Models.AccountModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
