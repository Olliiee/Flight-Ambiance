using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class FlightStatusUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParkingBrakeSet",
                table: "FlightStatuses",
                newName: "IsParkingBrakeSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsParkingBrakeSet",
                table: "FlightStatuses",
                newName: "ParkingBrakeSet");
        }
    }
}
