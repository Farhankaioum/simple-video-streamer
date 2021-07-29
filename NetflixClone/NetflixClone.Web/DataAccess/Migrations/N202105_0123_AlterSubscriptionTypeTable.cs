using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202105_0123)]
    public class N202105_0123_AlterSubscriptionTypeTable : UpOnlyMigration
    {
        public override void Up()
        {
            Alter.Table("SubscriptionTypes")
                .AddColumn("Description").AsString().NotNullable()
                .AddColumn("ShortDescription").AsString().NotNullable()
                .AddColumn("Price").AsDouble().NotNullable()
                .AddColumn("DurationInMonth").AsInt32().NotNullable();
        }
    }
}
