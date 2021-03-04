using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseballPipeline.Server.Data.Migrations
{
    public partial class NotificationSubscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationSubscriptions",
                columns: table => new
                {
                    NotificationSubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P256dh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSubscriptions", x => x.NotificationSubscriptionId);
                });

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "8b3ced07-8881-445f-bb48-1ff5e2c2db41",
            //    column: "ConcurrencyStamp",
            //    value: "7b950ed9-2229-48c5-bc84-395da782e996");

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "d92395eb-522f-4cae-8757-44a842f08f4d",
            //    column: "ConcurrencyStamp",
            //    value: "d7e57101-9bc5-4151-8235-65d5c483ccec");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationSubscriptions");

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "8b3ced07-8881-445f-bb48-1ff5e2c2db41",
            //    column: "ConcurrencyStamp",
            //    value: "a5e591a4-b2dc-436e-bb86-a3c4cd012bf5");

            //migrationBuilder.UpdateData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "d92395eb-522f-4cae-8757-44a842f08f4d",
            //    column: "ConcurrencyStamp",
            //    value: "deac2df5-f01d-46f3-9086-d0ecb5e565aa");
        }
    }
}
