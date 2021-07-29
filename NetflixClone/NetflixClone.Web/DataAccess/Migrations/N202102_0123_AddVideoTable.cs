using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202102_0123)]
    public class N202102_0123_AddVideoTable : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Videos")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("ReleasedDate").AsDateTime2().NotNullable()
                .WithColumn("CategoryId").AsInt32().Nullable()
                .WithColumn("Url").AsString().NotNullable();

            Create.ForeignKey("FK_Videos_Categories")
                .FromTable("Videos").ForeignColumn("CategoryId")
                .ToTable("Categories").PrimaryColumn("Id");
        }
    }
}
