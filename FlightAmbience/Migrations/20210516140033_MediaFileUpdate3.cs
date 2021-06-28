using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class MediaFileUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAmbiance",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "IsMusic",
                table: "MediaFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAmbiance",
                table: "MediaFiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMusic",
                table: "MediaFiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
