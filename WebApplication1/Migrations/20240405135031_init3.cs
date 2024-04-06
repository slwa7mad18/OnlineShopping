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
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c0494452-0c9d-446b-9d0f-aa6a31188c93", "37994443-c497-4788-9b96-b0a1b52fba6a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "12ed2cbf-b267-4388-9d9a-1720a3b869eb", "fd97ee0f-43b1-4df2-8409-6caa91f043c5" });
        }
    }
}
