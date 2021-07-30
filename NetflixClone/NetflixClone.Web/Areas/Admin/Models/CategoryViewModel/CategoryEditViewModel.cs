using Autofac;
using NetflixClone.Foundation.Services;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.CategoryViewModel
{
    public class CategoryEditViewModel : AdminBaseModel
    {
        private readonly ICategoryService _categoryService;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public CategoryEditViewModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public void Edit()
        {
            var existingCategory = _categoryService.GetCategoryById(Id);
            existingCategory.Name = Name;
            _categoryService.UpdateCategory(existingCategory);
        }

        public void GetCategoryById(int id)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            Id = existingCategory.Id;
            Name = existingCategory.Name;
        }
    }
}
