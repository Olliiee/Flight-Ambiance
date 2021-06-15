using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class statusprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightProfileProfileId",
                table: "Profiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "FlightStatuses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlightStatusProfiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightStatusProfiles", x => x.ProfileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_FlightProfileProfileId",
                table: "Profiles",
                column: "FlightProfileProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStatuses_ProfileId",
                table: "FlightStatuses",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightStatuses_FlightStatusProfiles_ProfileId",
                table: "FlightStatuses",
                column: "ProfileId",
                principalTable: "FlightStatusProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_FlightStatusProfiles_FlightProfileProfileId",
                table: "Profiles",
                column: "FlightProfileProfileId",
                principalTable: "FlightStatusProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightStatuses_FlightStatusProfiles_ProfileId",
                table: "FlightStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_FlightStatusProfiles_FlightProfileProfileId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "FlightStatusProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_FlightProfileProfileId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_FlightStatuses_ProfileId",
                table: "FlightStatuses");

            migrationBuilder.DropColumn(
                name: "FlightProfileProfileId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "FlightStatuses");
        }
    }
}
