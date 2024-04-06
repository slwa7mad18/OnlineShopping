using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2615323-1886-45e3-b54a-9484e87e2458", "259dbb6c-0f09-40d8-81d0-f3bb27df5512" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c0494452-0c9d-446b-9d0f-aa6a31188c93", "37994443-c497-4788-9b96-b0a1b52fba6a" });
        }
    }
}
