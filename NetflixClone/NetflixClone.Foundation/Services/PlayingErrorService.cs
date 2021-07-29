using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Repositories;
using System;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Services
{
    public class PlayingErrorService : IPlayingErrorService
    {
        private readonly IRepository<PlayingError, Guid> _repository;

        public PlayingErrorService(IRepository<PlayingError, Guid> repository)
        {
            _repository = repository;
        }

        public void AddPlayingError(PlayingError playingError)
        {
            _repository.Insert(playingError);
        }

        public void DeletePlayingError(PlayingError playingError)
        {
            _repository.Delete(playingError);
        }

        public PlayingError GetPlayingErrorById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IList<PlayingError> PlayingErrorList()
        {
            return _repository.GetList();
        }

        public void UpdatePlayingError(PlayingError playingError)
        {
            _repository.Update(playingError);
        }
    }
}
