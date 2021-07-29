using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Repositories;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<VideoCategory, int> _repository;

        public CategoryService(IRepository<VideoCategory, int> repository)
        {
            _repository = repository;
        }

        public void AddCategory(VideoCategory category)
        {
            var count = _repository.GetCount(x => x.Name == category.Name);

            if (count > 0)
            {
                throw new DuplicationException("Name Already Exists");
            }

            _repository.Insert(category);
        }

        public IList<VideoCategory> CategoryList()
        {
            return _repository.GetList();
        }

        public void DeleteCategory(VideoCategory category)
        {
            _repository.Delete(category);
        }

        public VideoCategory GetCategoryById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateCategory(VideoCategory category)
        {
            var count = _repository.GetCount(x => x.Name == category.Name && x.Id != category.Id);

            if (count > 0)
            {
                throw new DuplicationException("Name Already Exists");
            }

            _repository.Update(category);
        }
    }
}
