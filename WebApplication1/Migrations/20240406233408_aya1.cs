using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class aya1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e1468d3c-263a-4bcb-a1a5-f7099ce09ffb", "6fc82421-3d24-4d82-840f-9e3f99e7aff9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59b74f46-825f-441d-a8b7-18f1e84a9e69", "39840014-5f5a-41d3-962f-abd4417b5243" });
        }
    }
}
