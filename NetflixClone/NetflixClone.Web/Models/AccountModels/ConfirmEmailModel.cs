using Microsoft.AspNetCore.Mvc;

namespace NetflixClone.Web.Models.AccountModels
{
    public class ConfirmEmailModel
    {
        [TempData]
        public string StatusMessage { get; set; }
    }
}
