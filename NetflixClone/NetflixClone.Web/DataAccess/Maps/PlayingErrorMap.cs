using FluentNHibernate.Mapping;
using NetflixClone.Foundation.Entities;

namespace NetflixClone.Web.DataAccess.Maps
{
    public class PlayingErrorMap : ClassMap<PlayingError>
    {
        public PlayingErrorMap()
        {
            Id(x => x.Id);
            Map(x => x.Error);
            Map(x => x.UserId);
            Map(x => x.VideoId);
            Map(x => x.Duration);
            Map(x => x.DateTime);
            Table("PlayingErrors");
        }
    }
}
