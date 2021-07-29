using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Repositories;
using System;
using System.Collections.Generic;

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
            var count = _repository.GetCount(x => x.Title == video.Title);

            if (count > 0)
            {
                throw new DuplicationException("Title Already Exists");
            }
            _repository.Insert(video);
        }

        public void UpdateVideo(Video video)
        {
            var count = _repository.GetCount(x => x.Title == video.Title && x.Id != video.Id);

            if (count > 0)
            {
                throw new DuplicationException("Title Already Exists");
            }

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
