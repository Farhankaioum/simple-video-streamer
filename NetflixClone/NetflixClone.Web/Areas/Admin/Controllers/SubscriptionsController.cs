using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Areas.Admin.Models.SubscriptionViewModel;
using NetflixClone.Web.Controllers;
using System;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscriptionsController : BaseController
    {
        private readonly ILogger<SubscriptionsController> _logger;
        private readonly INotyfService _notyf;

        public SubscriptionsController(
            UserManager<ApplicationUser> userManager,
            ILogger<SubscriptionsController> logger,
            INotyfService notyf
            )
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

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SubscriptionCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubscriptionCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.CreateSubscription();
                _notyf.Success("Subscription create successful!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                _notyf.Error(ex.Message);
                _logger.LogError(ex.Message, ex);
            } 

            return View(model);
        }
    }
}
