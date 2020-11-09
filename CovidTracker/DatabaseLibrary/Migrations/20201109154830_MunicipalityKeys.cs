using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class MunicipalityKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Municipalities_LivesInName",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_LivesInName",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "LivesInName",
                table: "Citizens");

            migrationBuilder.AddColumn<string>(
                name: "MunicipalityName",
                table: "Citizens",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_MunicipalityName",
                table: "Citizens",
                column: "MunicipalityName");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Municipalities_MunicipalityName",
                table: "Citizens",
                column: "MunicipalityName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Municipalities_MunicipalityName",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_MunicipalityName",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "MunicipalityName",
                table: "Citizens");

            migrationBuilder.AddColumn<string>(
                name: "LivesInName",
                table: "Citizens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_LivesInName",
                table: "Citizens",
                column: "LivesInName");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Municipalities_LivesInName",
                table: "Citizens",
                column: "LivesInName",
                principalTable: "Municipalities",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
