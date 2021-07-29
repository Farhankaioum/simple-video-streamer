using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using NetflixClone.Web.Areas.Admin.Models.CategoryViewModel;
using NetflixClone.Web.Controllers;
using System;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly INotyfService _notyf;

        public CategoryController(
            UserManager<ApplicationUser> userManager,
            ILogger<CategoryController> logger,
            INotyfService notyf
            )
            : base(userManager)
        {
            _notyf = notyf;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new CategoryIndexViewModel();
            model.LoadModelData();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.Create();
                _notyf.Success("Category added successful!");
            }
            catch(Exception ex)
            {
                _notyf.Error(ex.Message);
                _logger.LogError(ex.Message, ex);
            }

            return View(model);
        }
    }
}
