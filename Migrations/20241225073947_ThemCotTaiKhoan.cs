using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    /// <inheritdoc />
    public partial class ThemCotTaiKhoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LOAIACCOUNT",
                table: "taiKhoans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PASS",
                table: "taiKhoans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "USERNAME",
                table: "taiKhoans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOAIACCOUNT",
                table: "taiKhoans");

            migrationBuilder.DropColumn(
                name: "PASS",
                table: "taiKhoans");

            migrationBuilder.DropColumn(
                name: "USERNAME",
                table: "taiKhoans");
        }
    }
}
