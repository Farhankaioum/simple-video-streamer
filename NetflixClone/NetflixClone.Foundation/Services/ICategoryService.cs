using NetflixClone.Foundation.Entities;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Services
{
    public interface ICategoryService
    {
        void AddCategory(VideoCategory category);
        IList<VideoCategory> CategoryList();
        VideoCategory GetCategoryById(int id);
        void UpdateCategory(VideoCategory category);
        void DeleteCategory(VideoCategory category);
    }
}
