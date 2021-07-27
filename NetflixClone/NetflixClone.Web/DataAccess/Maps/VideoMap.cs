using FluentNHibernate.Mapping;
using NetflixClone.Foundation.Entities;

namespace NetflixClone.Foundation.Settings.Maps
{
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Url);
            Table("Videos");
        }
    }
}
