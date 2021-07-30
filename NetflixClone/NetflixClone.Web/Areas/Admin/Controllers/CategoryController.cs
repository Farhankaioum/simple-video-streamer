using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Helpers;
using NetflixClone.Web.Areas.Admin.Models.CategoryViewModel;
using NetflixClone.Web.Controllers;
using System;

namespace NetflixClone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ConstantValue.ADMIN_USER_ROLE)]
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
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _notyf.Error(ex.Message);
                _logger.LogError(ex.Message, ex);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new CategoryEditViewModel();
            model.GetCategoryById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.Edit();
                _notyf.Success("Category update successful!");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                _logger.LogError(ex.Message, ex);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = new CategoryIndexViewModel();
                model.DeleteCategory(id);
                _notyf.Success("Category delete successful!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                _notyf.Error(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
