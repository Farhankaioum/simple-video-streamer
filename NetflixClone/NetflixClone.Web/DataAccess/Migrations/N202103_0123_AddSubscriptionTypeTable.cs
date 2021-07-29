using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202103_0123)]
    public class N202103_0123_AddSubscriptionTypeTable : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("SubscriptionTypes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("CreatedAt").AsDateTime2().NotNullable();
        }
    }
}
