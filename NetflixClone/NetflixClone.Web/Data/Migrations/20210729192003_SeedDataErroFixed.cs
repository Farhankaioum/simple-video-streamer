using Microsoft.EntityFrameworkCore.Migrations;

namespace NetflixClone.Web.Data.Migrations
{
    public partial class SeedDataErroFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "791056c5-9f75-4d0f-b814-2670fdad2ad7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c293918-75a2-44bb-acf6-8b004c057b9c", "AQAAAAEAACcQAAAAELbMeVaNhJygIIaFqNf8SjluEN2vtPipXiXSRK3Kx/c31fB/AsjxYnMuwx1m4osBJw==", "83fca165-494a-4847-98b4-f0283c273456" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0df8bca8-90de-4d76-b1ff-d8fbffcc96a1", "AQAAAAEAACcQAAAAEBoESAdBkzMc6QAZZMNxT5kobit67JRch4TuLfcN8J0NihfP6iOaAf+YL0sKiIpScw==", "86866665-fab6-4b7e-bdfa-9b58ea7fc898" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "791056c5-9f75-4d0f-b814-2670fdad2ad7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcaab3d3-ef6b-4d76-bff2-f83ef1cb3a20", null, "5a7c820a-1696-4528-861a-69b825bb09c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f45f72b-e8f5-4b6c-8cb7-373d17eebef4", null, "e6b6b8c6-cfbf-44b2-a086-453dabb3cef7" });
        }
    }
}
