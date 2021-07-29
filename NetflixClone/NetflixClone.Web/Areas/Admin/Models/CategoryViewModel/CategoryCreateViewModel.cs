using Autofac;
using NetflixClone.Foundation.Services;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.CategoryViewModel
{
    public class CategoryCreateViewModel
    {
        private readonly ICategoryService _categoryService;

        [Required]
        public string Name { get; set; }

        public CategoryCreateViewModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public void Create()
        {
            _categoryService.AddCategory(
                new Foundation.Entities.VideoCategory
                {
                    Name = Name
                });
        }
    }
}
