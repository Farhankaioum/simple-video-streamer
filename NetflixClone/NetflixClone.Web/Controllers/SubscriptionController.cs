using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Models.SubscriptionViewModel;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetflixClone.Web.Controllers
{
    [Authorize]
    public class SubscriptionController : BaseController
    {
        private readonly INotyfService _notyf;
        private readonly ILogger<SubscriptionController> _logger;

        public SubscriptionController(
            UserManager<ApplicationUser> userManager,
            INotyfService notyf,
            ILogger<SubscriptionController> logger)
            : base(userManager)
        {
            _notyf = notyf;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new SubscriptionIndexViewModel();
            model.LoadModelData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  ApplySubscription(int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest();

            var model = new SubscriptionIndexViewModel();
            try
            {
                var result = await model.AddUserSubscription(userId, id);

                if (result)
                {
                    _notyf.Success("Your subscription added successfully!. Now you are subscribe user");
                    return RedirectToAction("Index", "Videos");
                }
                else
                {
                    _notyf.Error("Error occured when added subscription");
                }
            }
            catch (Exception ex)
            {
                _notyf.Error("Error occured when added subscription");
                _logger.LogError(ex.Message, ex);
            }

            return View(nameof(Index));
        }
    }
}
