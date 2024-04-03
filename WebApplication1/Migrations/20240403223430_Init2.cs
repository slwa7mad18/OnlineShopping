using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "12ed2cbf-b267-4388-9d9a-1720a3b869eb", "01120080013", "fd97ee0f-43b1-4df2-8409-6caa91f043c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "MobilePhone", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "ec8f8694-3e86-426a-bd18-f36bdca7b60d", "01120080013", null, "39719394-fbca-410f-80ac-6827529433cd" });
        }
    }
}
