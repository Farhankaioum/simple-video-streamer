using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202101_0123)]
    public class N202101_0123_AddVideoTable : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Videos")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("Url").AsString().NotNullable();
        }
    }
}
