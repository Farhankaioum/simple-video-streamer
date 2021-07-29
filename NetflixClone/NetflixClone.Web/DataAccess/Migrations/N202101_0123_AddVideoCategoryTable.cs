using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202101_0123)]
    public class N202101_0123_AddVideoCategoryTable : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }
    }
}
