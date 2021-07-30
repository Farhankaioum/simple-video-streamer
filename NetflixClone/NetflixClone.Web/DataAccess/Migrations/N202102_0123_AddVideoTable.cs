using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202102_0123)]
    public class N202102_0123_AddVideoTable : UpOnlyMigration
    {
        public override void Up()
        {
            const string tableName = "Videos";
            const string categoryIdColumn = "CategoryId";

            Create.Table(tableName)
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("ReleasedDate").AsDateTime2().NotNullable()
                .WithColumn(categoryIdColumn).AsInt32().Nullable()
                .WithColumn("Url").AsString().NotNullable();

            Create.ForeignKey()
                .FromTable(tableName).ForeignColumn(categoryIdColumn)
                .ToTable("Categories").PrimaryColumn("Id");
        }
    }
}
