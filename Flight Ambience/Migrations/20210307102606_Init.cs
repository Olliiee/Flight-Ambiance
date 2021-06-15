using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightStatuses",
                columns: table => new
                {
                    FlightStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FlightStatusName = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingore = table.Column<bool>(type: "INTEGER", nullable: false),
                    Door = table.Column<bool>(type: "INTEGER", nullable: false),
                    EngineRun = table.Column<bool>(type: "INTEGER", nullable: false),
                    OnGround = table.Column<bool>(type: "INTEGER", nullable: false),
                    GearDown = table.Column<bool>(type: "INTEGER", nullable: false),
                    RadioAltitude = table.Column<int>(type: "INTEGER", nullable: false),
                    GroundSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    Ambiance = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlightAmbiance = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightStatuses", x => x.FlightStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Setting = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileItems",
                columns: table => new
                {
                    ProfileItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileItems", x => x.ProfileItemId);
                    table.ForeignKey(
                        name: "FK_ProfileItems_FlightStatuses_FlightStatusId",
                        column: x => x.FlightStatusId,
                        principalTable: "FlightStatuses",
                        principalColumn: "FlightStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileItems_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    MediaFileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsAmbiance = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMusic = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProfileItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.MediaFileId);
                    table.ForeignKey(
                        name: "FK_MediaFiles_ProfileItems_ProfileItemId",
                        column: x => x.ProfileItemId,
                        principalTable: "ProfileItems",
                        principalColumn: "ProfileItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ProfileItemId",
                table: "MediaFiles",
                column: "ProfileItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileItems_FlightStatusId",
                table: "ProfileItems",
                column: "FlightStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileItems_ProfileId",
                table: "ProfileItems",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "ProfileItems");

            migrationBuilder.DropTable(
                name: "FlightStatuses");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
