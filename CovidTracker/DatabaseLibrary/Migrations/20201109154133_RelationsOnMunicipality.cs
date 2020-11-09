using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class RelationsOnMunicipality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MunicipalityName",
                table: "Location",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_MunicipalityName",
                table: "Location",
                column: "MunicipalityName");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Municipalities_MunicipalityName",
                table: "Location",
                column: "MunicipalityName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Municipalities_MunicipalityName",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_MunicipalityName",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "MunicipalityName",
                table: "Location");
        }
    }
}
