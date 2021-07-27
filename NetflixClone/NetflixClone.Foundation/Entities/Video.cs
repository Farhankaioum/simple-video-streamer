using System;

namespace NetflixClone.Foundation.Entities
{
    public class Video
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Url { get; set; }
    }
}
