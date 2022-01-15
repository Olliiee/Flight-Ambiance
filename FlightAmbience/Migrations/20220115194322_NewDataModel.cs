using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Strausshome.FS.CrewSoundsNG.Migrations
{
    public partial class NewDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightStatuses_FlightStatusProfiles_ProfileId",
                table: "FlightStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileItems_FlightStatuses_FlightStatusId",
                table: "ProfileItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileItems_Profiles_ProfileId",
                table: "ProfileItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_FlightStatusProfiles_FlightProfileProfileId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_FlightProfileProfileId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FlightProfileProfileId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MediaFileId",
                table: "ProfileItems");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "FlightStatuses",
                newName: "FlightStatusProfileProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightStatuses_ProfileId",
                table: "FlightStatuses",
                newName: "IX_FlightStatuses_FlightStatusProfileProfileId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "ProfileItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FlightStatusId",
                table: "ProfileItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightStatuses_FlightStatusProfiles_FlightStatusProfileProfileId",
                table: "FlightStatuses",
                column: "FlightStatusProfileProfileId",
                principalTable: "FlightStatusProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileItems_FlightStatuses_FlightStatusId",
                table: "ProfileItems",
                column: "FlightStatusId",
                principalTable: "FlightStatuses",
                principalColumn: "FlightStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileItems_Profiles_ProfileId",
                table: "ProfileItems",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightStatuses_FlightStatusProfiles_FlightStatusProfileProfileId",
                table: "FlightStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileItems_FlightStatuses_FlightStatusId",
                table: "ProfileItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileItems_Profiles_ProfileId",
                table: "ProfileItems");

            migrationBuilder.RenameColumn(
                name: "FlightStatusProfileProfileId",
                table: "FlightStatuses",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightStatuses_FlightStatusProfileProfileId",
                table: "FlightStatuses",
                newName: "IX_FlightStatuses_ProfileId");

            migrationBuilder.AddColumn<int>(
                name: "FlightProfileProfileId",
                table: "Profiles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "ProfileItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlightStatusId",
                table: "ProfileItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaFileId",
                table: "ProfileItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_FlightProfileProfileId",
                table: "Profiles",
                column: "FlightProfileProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightStatuses_FlightStatusProfiles_ProfileId",
                table: "FlightStatuses",
                column: "ProfileId",
                principalTable: "FlightStatusProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileItems_FlightStatuses_FlightStatusId",
                table: "ProfileItems",
                column: "FlightStatusId",
                principalTable: "FlightStatuses",
                principalColumn: "FlightStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileItems_Profiles_ProfileId",
                table: "ProfileItems",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_FlightStatusProfiles_FlightProfileProfileId",
                table: "Profiles",
                column: "FlightProfileProfileId",
                principalTable: "FlightStatusProfiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
