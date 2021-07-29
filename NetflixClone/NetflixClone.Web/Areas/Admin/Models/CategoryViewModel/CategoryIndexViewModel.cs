using Autofac;
using NetflixClone.Foundation.Services;
using System.Collections.Generic;

namespace NetflixClone.Web.Areas.Admin.Models.CategoryViewModel
{
    public class CategoryIndexViewModel
    {
        private readonly ICategoryService _categoryService;

        public string Name { get; set; }
        public int Id { get; set; }

        public List<CategoryIndexViewModel> CategoryList { get; set; }

        public CategoryIndexViewModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            CategoryList = new List<CategoryIndexViewModel>();
        }

        public void LoadModelData()
        {
            var categories = _categoryService.CategoryList();
            foreach(var category in categories)
            {
                CategoryList.Add(new CategoryIndexViewModel 
                { 
                    Id = category.Id,
                    Name = category.Name
                });
            }
        }
    }
}
