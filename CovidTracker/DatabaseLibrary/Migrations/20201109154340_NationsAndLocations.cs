using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class NationsAndLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenWasAtLocation_Location_VisitedLocationAddress",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Municipalities_MunicipalityName",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_Location_MunicipalityName",
                table: "Locations",
                newName: "IX_Locations_MunicipalityName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Address");

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.Name);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocation_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                column: "VisitedLocationAddress",
                principalTable: "Locations",
                principalColumn: "Address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Municipalities_MunicipalityName",
                table: "Locations",
                column: "MunicipalityName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenWasAtLocation_Locations_VisitedLocationAddress",
                table: "CitizenWasAtLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Municipalities_MunicipalityName",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Nations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MunicipalityName",
                table: "Location",
                newName: "IX_Location_MunicipalityName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenWasAtLocation_Location_VisitedLocationAddress",
                table: "CitizenWasAtLocation",
                column: "VisitedLocationAddress",
                principalTable: "Location",
                principalColumn: "Address",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Municipalities_MunicipalityName",
                table: "Location",
                column: "MunicipalityName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
