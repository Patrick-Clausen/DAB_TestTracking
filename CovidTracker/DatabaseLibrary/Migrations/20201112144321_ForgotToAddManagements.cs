using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class ForgotToAddManagements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenters_TestCenterManagement_ManagementName",
                table: "TestCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCenterManagement",
                table: "TestCenterManagement");

            migrationBuilder.RenameTable(
                name: "TestCenterManagement",
                newName: "TestCenterManagements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCenterManagements",
                table: "TestCenterManagements",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenters_TestCenterManagements_ManagementName",
                table: "TestCenters",
                column: "ManagementName",
                principalTable: "TestCenterManagements",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenters_TestCenterManagements_ManagementName",
                table: "TestCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCenterManagements",
                table: "TestCenterManagements");

            migrationBuilder.RenameTable(
                name: "TestCenterManagements",
                newName: "TestCenterManagement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCenterManagement",
                table: "TestCenterManagement",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenters_TestCenterManagement_ManagementName",
                table: "TestCenters",
                column: "ManagementName",
                principalTable: "TestCenterManagement",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
