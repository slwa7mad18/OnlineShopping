using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59b74f46-825f-441d-a8b7-18f1e84a9e69", "39840014-5f5a-41d3-962f-abd4417b5243" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "557f88fd-c596-4b04-8625-27620b28c23b", "157aba40-c2a9-47d5-af9a-e477566a0994" });
        }
    }
}
