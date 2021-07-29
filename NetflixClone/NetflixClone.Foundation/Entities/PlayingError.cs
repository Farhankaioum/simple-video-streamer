using System;

namespace NetflixClone.Foundation.Entities
{
    public class PlayingError : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string UserId { get; set; }
        public virtual string VideoId { get; set; }
        public virtual string Error { get; set; }
        public virtual string Duration { get; set; }
        public virtual DateTime DateTime { get; set; }
    }
}
