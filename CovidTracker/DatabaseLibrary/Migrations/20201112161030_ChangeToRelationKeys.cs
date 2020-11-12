using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class ChangeToRelationKeys : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "VisitingCitizenSSN",
                table: "CitizenWasAtLocation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CitizenWasAtLocation",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "TestCenterName",
                table: "CitizenTestedAtTestCenter",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CitizenSSN",
                table: "CitizenTestedAtTestCenter",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CitizenTestedAtTestCenter",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenWasAtLocation",
                table: "CitizenWasAtLocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenTestedAtTestCenter",
                table: "CitizenTestedAtTestCenter",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenWasAtLocation_VisitingCitizenSSN",
                table: "CitizenWasAtLocation",
                column: "VisitingCitizenSSN");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenTestedAtTestCenter_CitizenSSN",
                table: "CitizenTestedAtTestCenter",
                column: "CitizenSSN");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_CitizenWasAtLocation_VisitingCitizenSSN",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CitizenTestedAtTestCenter",
                table: "CitizenTestedAtTestCenter");

            migrationBuilder.DropIndex(
                name: "IX_CitizenTestedAtTestCenter_CitizenSSN",
                table: "CitizenTestedAtTestCenter");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CitizenTestedAtTestCenter");

            migrationBuilder.AlterColumn<string>(
                name: "VisitingCitizenSSN",
                table: "CitizenWasAtLocation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestCenterName",
                table: "CitizenTestedAtTestCenter",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CitizenSSN",
                table: "CitizenTestedAtTestCenter",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenWasAtLocation",
                table: "CitizenWasAtLocation",
                columns: new[] { "VisitingCitizenSSN", "VisitedLocationAddress" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CitizenTestedAtTestCenter",
                table: "CitizenTestedAtTestCenter",
                columns: new[] { "CitizenSSN", "TestCenterName" });

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenTestedAtTestCenter_Citizens_CitizenSSN",
                table: "CitizenTestedAtTestCenter",
                column: "CitizenSSN",
                principalTable: "Citizens",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenTestedAtTestCenter_TestCenters_TestCenterName",
                table: "CitizenTestedAtTestCenter",
                column: "TestCenterName",
                principalTable: "TestCenters",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocation_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                column: "VisitedLocationAddress",
                principalTable: "Locations",
                principalColumn: "Address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocation_Citizens_VisitingCitizenSSN",
                table: "CitizenWasAtLocation",
                column: "VisitingCitizenSSN",
                principalTable: "Citizens",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
