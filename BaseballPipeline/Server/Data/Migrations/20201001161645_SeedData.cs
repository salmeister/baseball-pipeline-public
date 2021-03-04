using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseballPipeline.Server.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b3ced07-8881-445f-bb48-1ff5e2c2db41",
                column: "ConcurrencyStamp",
                value: "a5e591a4-b2dc-436e-bb86-a3c4cd012bf5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d92395eb-522f-4cae-8757-44a842f08f4d",
                column: "ConcurrencyStamp",
                value: "deac2df5-f01d-46f3-9086-d0ecb5e565aa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b3ced07-8881-445f-bb48-1ff5e2c2db41",
                column: "ConcurrencyStamp",
                value: "a221e826-f953-4e9b-b216-d096a034bb20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d92395eb-522f-4cae-8757-44a842f08f4d",
                column: "ConcurrencyStamp",
                value: "8f53319e-004c-4c6c-94c7-3fe78f6226e9");
        }
    }
}
