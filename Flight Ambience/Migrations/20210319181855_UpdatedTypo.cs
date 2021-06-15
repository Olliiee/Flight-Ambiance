using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class UpdatedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingore",
                table: "FlightStatuses",
                newName: "Ignore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ignore",
                table: "FlightStatuses",
                newName: "Ingore");
        }
    }
}
