using FluentNHibernate.Mapping;
using NetflixClone.Foundation.Entities;

namespace NetflixClone.Web.DataAccess.Maps
{
    public class VideoCategoryMap : ClassMap<VideoCategory>
    {
        public VideoCategoryMap()
        {
            Table("Categories");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
        }
    }
}
