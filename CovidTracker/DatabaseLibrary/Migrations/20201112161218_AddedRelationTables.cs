using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class AddedRelationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenTestedAtTestCenter_Citizens_CitizenSSN",
                table: "CitizenTestedAtTestCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenTestedAtTestCenter_TestCenters_TestCenterName",
                table: "CitizenTestedAtTestCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenWasAtLocation_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenWasAtLocation_Citizens_VisitingCitizenSSN",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenWasAtLocation",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenTestedAtTestCenter",
                table: "CitizenTestedAtTestCenter");

            migrationBuilder.RenameTable(
                name: "CitizenWasAtLocation",
                newName: "CitizenWasAtLocations");

            migrationBuilder.RenameTable(
                name: "CitizenTestedAtTestCenter",
                newName: "CitizenTestedAtTestCenters");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenWasAtLocation_VisitingCitizenSSN",
                table: "CitizenWasAtLocations",
                newName: "IX_CitizenWasAtLocations_VisitingCitizenSSN");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenWasAtLocation_VisitedLocationAddress",
                table: "CitizenWasAtLocations",
                newName: "IX_CitizenWasAtLocations_VisitedLocationAddress");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenTestedAtTestCenter_TestCenterName",
                table: "CitizenTestedAtTestCenters",
                newName: "IX_CitizenTestedAtTestCenters_TestCenterName");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenTestedAtTestCenter_CitizenSSN",
                table: "CitizenTestedAtTestCenters",
                newName: "IX_CitizenTestedAtTestCenters_CitizenSSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenWasAtLocations",
                table: "CitizenWasAtLocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenTestedAtTestCenters",
                table: "CitizenTestedAtTestCenters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenTestedAtTestCenters_Citizens_CitizenSSN",
                table: "CitizenTestedAtTestCenters",
                column: "CitizenSSN",
                principalTable: "Citizens",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenTestedAtTestCenters_TestCenters_TestCenterName",
                table: "CitizenTestedAtTestCenters",
                column: "TestCenterName",
                principalTable: "TestCenters",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocations_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocations",
                column: "VisitedLocationAddress",
                principalTable: "Locations",
                principalColumn: "Address",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocations_Citizens_VisitingCitizenSSN",
                table: "CitizenWasAtLocations",
                column: "VisitingCitizenSSN",
                principalTable: "Citizens",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenTestedAtTestCenters_Citizens_CitizenSSN",
                table: "CitizenTestedAtTestCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenTestedAtTestCenters_TestCenters_TestCenterName",
                table: "CitizenTestedAtTestCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenWasAtLocations_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenWasAtLocations_Citizens_VisitingCitizenSSN",
                table: "CitizenWasAtLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenWasAtLocations",
                table: "CitizenWasAtLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenTestedAtTestCenters",
                table: "CitizenTestedAtTestCenters");

            migrationBuilder.RenameTable(
                name: "CitizenWasAtLocations",
                newName: "CitizenWasAtLocation");

            migrationBuilder.RenameTable(
                name: "CitizenTestedAtTestCenters",
                newName: "CitizenTestedAtTestCenter");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenWasAtLocations_VisitingCitizenSSN",
                table: "CitizenWasAtLocation",
                newName: "IX_CitizenWasAtLocation_VisitingCitizenSSN");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenWasAtLocations_VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                newName: "IX_CitizenWasAtLocation_VisitedLocationAddress");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenTestedAtTestCenters_TestCenterName",
                table: "CitizenTestedAtTestCenter",
                newName: "IX_CitizenTestedAtTestCenter_TestCenterName");

            migrationBuilder.RenameIndex(
                name: "IX_CitizenTestedAtTestCenters_CitizenSSN",
                table: "CitizenTestedAtTestCenter",
                newName: "IX_CitizenTestedAtTestCenter_CitizenSSN");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenWasAtLocation",
                table: "CitizenWasAtLocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenTestedAtTestCenter",
                table: "CitizenTestedAtTestCenter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenTestedAtTestCenter_Citizens_CitizenSSN",
                table: "CitizenTestedAtTestCenter",
                column: "CitizenSSN",
                principalTable: "Citizens",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenTestedAtTestCenter_TestCenters_TestCenterName",
                table: "CitizenTestedAtTestCenter",
                column: "TestCenterName",
                principalTable: "TestCenters",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocation_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                column: "VisitedLocationAddress",
                principalTable: "Locations",
                principalColumn: "Address",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocation_Citizens_VisitingCitizenSSN",
                table: "CitizenWasAtLocation",
                column: "VisitingCitizenSSN",
                principalTable: "Citizens",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
