using NetflixClone.Foundation.Entities;
using System;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Services
{
    public interface IPlayingErrorService
    {
        void AddPlayingError(PlayingError playingError);
        IList<PlayingError> PlayingErrorList();
        PlayingError GetPlayingErrorById(Guid id);
        void UpdatePlayingError(PlayingError playingError);
        void DeletePlayingError(PlayingError playingError);
    }
}
