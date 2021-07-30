using FluentNHibernate.Mapping;
using NetflixClone.Foundation.Entities;

namespace NetflixClone.Web.DataAccess.Maps
{
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Table("Videos");

            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Url);
            Map(x => x.ReleasedDate);

            References(x => x.Category)
                .Column("CategoryId")
                .Nullable()
                .Cascade.All();
        }
    }
}
