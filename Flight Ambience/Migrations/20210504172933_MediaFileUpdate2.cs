using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class MediaFileUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightAmbiance",
                table: "FlightStatuses");

            migrationBuilder.DropColumn(
                name: "GroundAmbiance",
                table: "FlightStatuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FlightAmbiance",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GroundAmbiance",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
