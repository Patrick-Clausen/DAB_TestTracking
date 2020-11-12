using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class TestCenterIsInLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenters_Municipalities_PlacedInName",
                table: "TestCenters");

            migrationBuilder.DropIndex(
                name: "IX_TestCenters_PlacedInName",
                table: "TestCenters");

            migrationBuilder.DropColumn(
                name: "PlacedInName",
                table: "TestCenters");

            migrationBuilder.AddColumn<string>(
                name: "LocationAddress",
                table: "TestCenters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCenters_LocationAddress",
                table: "TestCenters",
                column: "LocationAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenters_Locations_LocationAddress",
                table: "TestCenters",
                column: "LocationAddress",
                principalTable: "Locations",
                principalColumn: "Address",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenters_Locations_LocationAddress",
                table: "TestCenters");

            migrationBuilder.DropIndex(
                name: "IX_TestCenters_LocationAddress",
                table: "TestCenters");

            migrationBuilder.DropColumn(
                name: "LocationAddress",
                table: "TestCenters");

            migrationBuilder.AddColumn<string>(
                name: "PlacedInName",
                table: "TestCenters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestCenters_PlacedInName",
                table: "TestCenters",
                column: "PlacedInName");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenters_Municipalities_PlacedInName",
                table: "TestCenters",
                column: "PlacedInName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
