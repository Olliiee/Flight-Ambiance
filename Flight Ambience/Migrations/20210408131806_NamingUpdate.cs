using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class NamingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seatbelts",
                table: "FlightStatuses",
                newName: "SeatbeltsSignOn");

            migrationBuilder.RenameColumn(
                name: "OnGround",
                table: "FlightStatuses",
                newName: "IsOnGround");

            migrationBuilder.RenameColumn(
                name: "GearDown",
                table: "FlightStatuses",
                newName: "IsGearDown");

            migrationBuilder.RenameColumn(
                name: "EngineRun",
                table: "FlightStatuses",
                newName: "IsEngineRun");

            migrationBuilder.RenameColumn(
                name: "Door",
                table: "FlightStatuses",
                newName: "IsDoorOpen");

            migrationBuilder.RenameColumn(
                name: "Ambiance",
                table: "FlightStatuses",
                newName: "GroundAmbiance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatbeltsSignOn",
                table: "FlightStatuses",
                newName: "Seatbelts");

            migrationBuilder.RenameColumn(
                name: "IsOnGround",
                table: "FlightStatuses",
                newName: "OnGround");

            migrationBuilder.RenameColumn(
                name: "IsGearDown",
                table: "FlightStatuses",
                newName: "GearDown");

            migrationBuilder.RenameColumn(
                name: "IsEngineRun",
                table: "FlightStatuses",
                newName: "EngineRun");

            migrationBuilder.RenameColumn(
                name: "IsDoorOpen",
                table: "FlightStatuses",
                newName: "Door");

            migrationBuilder.RenameColumn(
                name: "GroundAmbiance",
                table: "FlightStatuses",
                newName: "Ambiance");
        }
    }
}
