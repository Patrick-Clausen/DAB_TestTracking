using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class Expanded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Citizens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LivesInName",
                table: "Citizens",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Address);
                });

            migrationBuilder.CreateTable(
                name: "TestCenters",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Hours = table.Column<string>(nullable: true),
                    PlacedInName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCenters", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TestCenters_Municipalities_PlacedInName",
                        column: x => x.PlacedInName,
                        principalTable: "Municipalities",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitizenWasAtLocation",
                columns: table => new
                {
                    VisitingCitizenSSN = table.Column<int>(nullable: false),
                    VisitedLocationAddress = table.Column<string>(nullable: false),
                    DateOfVisit = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenWasAtLocation", x => new { x.VisitingCitizenSSN, x.VisitedLocationAddress });
                    table.ForeignKey(
                        name: "FK_CitizenWasAtLocation_Location_VisitedLocationAddress",
                        column: x => x.VisitedLocationAddress,
                        principalTable: "Location",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenWasAtLocation_Citizens_VisitingCitizenSSN",
                        column: x => x.VisitingCitizenSSN,
                        principalTable: "Citizens",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitizenTestedAtTestCenter",
                columns: table => new
                {
                    CitizenSSN = table.Column<int>(nullable: false),
                    TestCenterName = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenTestedAtTestCenter", x => new { x.CitizenSSN, x.TestCenterName });
                    table.ForeignKey(
                        name: "FK_CitizenTestedAtTestCenter_Citizens_CitizenSSN",
                        column: x => x.CitizenSSN,
                        principalTable: "Citizens",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenTestedAtTestCenter_TestCenters_TestCenterName",
                        column: x => x.TestCenterName,
                        principalTable: "TestCenters",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCenterManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ManagedTestCenterName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCenterManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCenterManagement_TestCenters_ManagedTestCenterName",
                        column: x => x.ManagedTestCenterName,
                        principalTable: "TestCenters",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_LivesInName",
                table: "Citizens",
                column: "LivesInName");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenTestedAtTestCenter_TestCenterName",
                table: "CitizenTestedAtTestCenter",
                column: "TestCenterName");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenWasAtLocation_VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                column: "VisitedLocationAddress");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterManagement_ManagedTestCenterName",
                table: "TestCenterManagement",
                column: "ManagedTestCenterName",
                unique: true,
                filter: "[ManagedTestCenterName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenters_PlacedInName",
                table: "TestCenters",
                column: "PlacedInName");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Municipalities_LivesInName",
                table: "Citizens",
                column: "LivesInName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Municipalities_LivesInName",
                table: "Citizens");

            migrationBuilder.DropTable(
                name: "CitizenTestedAtTestCenter");

            migrationBuilder.DropTable(
                name: "CitizenWasAtLocation");

            migrationBuilder.DropTable(
                name: "TestCenterManagement");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "TestCenters");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_LivesInName",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "LivesInName",
                table: "Citizens");
        }
    }
}
