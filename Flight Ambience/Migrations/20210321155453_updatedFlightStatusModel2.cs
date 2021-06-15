using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class updatedFlightStatusModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seatbelts",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seatbelts",
                table: "FlightStatuses");
        }
    }
}
