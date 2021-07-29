using System.Collections.Generic;

namespace NetflixClone.Foundation.Entities
{
    public class VideoCategory
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Video> Videos { get; set; }

        public VideoCategory()
        {
            Videos = new List<Video>();
        }
    }
}
