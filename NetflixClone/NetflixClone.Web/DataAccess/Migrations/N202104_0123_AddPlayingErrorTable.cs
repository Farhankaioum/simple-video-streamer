using FluentMigrator;

namespace NetflixClone.Web.DataAccess.Migrations
{
    [Migration(202104_0123)]
    public class N202104_0123_AddPlayingErrorTable : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("PlayingErrors")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Error").AsString().Nullable()
                .WithColumn("UserId").AsString().Nullable()
                .WithColumn("VideoId").AsString().Nullable()
                .WithColumn("Duration").AsString().Nullable()
                .WithColumn("DateTime").AsDateTime2().Nullable();  
        }
    }
}
