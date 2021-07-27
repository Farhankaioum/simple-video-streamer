using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixClone.Foundation.Services
{
    public class VideoService : IVideoService
    {
        private readonly IRepository<Video, Guid> _repository;

        public VideoService(IRepository<Video, Guid> repository)
        {
            _repository = repository;
        }

        public void AddVideo(Video video)
        {
            _repository.Insert(video);
        }

        public void UpdateVideo(Video video)
        {
            _repository.Update(video);
        }

        public void DeleteVideo(Video video)
        {
            _repository.Delete(video);
        }

        public Video GetVideoById(Guid id)
        {
           return _repository.GetById(id);
        }

        public IList<Video> VideoList()
        {
            return _repository.GetList();
        }
    }
}
