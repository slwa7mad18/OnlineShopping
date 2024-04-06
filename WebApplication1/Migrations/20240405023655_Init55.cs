using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class Init55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dodo-soly-18111999",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "557f88fd-c596-4b04-8625-27620b28c23b", "157aba40-c2a9-47d5-af9a-e477566a0994" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adress",
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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "12ed2cbf-b267-4388-9d9a-1720a3b869eb", "fd97ee0f-43b1-4df2-8409-6caa91f043c5" });
        }
    }
}
