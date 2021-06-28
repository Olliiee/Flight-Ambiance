using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class updatedFlightStatusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Altitude",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AltitudeOperator",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerticalOperator",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerticalSpeed",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "FlightStatuses");

            migrationBuilder.DropColumn(
                name: "AltitudeOperator",
                table: "FlightStatuses");

            migrationBuilder.DropColumn(
                name: "VerticalOperator",
                table: "FlightStatuses");

            migrationBuilder.DropColumn(
                name: "VerticalSpeed",
                table: "FlightStatuses");
        }
    }
}
