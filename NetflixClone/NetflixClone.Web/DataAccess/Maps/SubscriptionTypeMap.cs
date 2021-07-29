using FluentNHibernate.Mapping;
using NetflixClone.Foundation.Entities;

namespace NetflixClone.Web.DataAccess.Maps
{
    public class SubscriptionTypeMap : ClassMap<SubscriptionType>
    {
        public SubscriptionTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.ShortDescription);
            Map(x => x.Price);
            Map(x => x.DurationInMonth);
            Map(x => x.CreatedAt);
            Table("SubscriptionTypes");
        }
    }
}
