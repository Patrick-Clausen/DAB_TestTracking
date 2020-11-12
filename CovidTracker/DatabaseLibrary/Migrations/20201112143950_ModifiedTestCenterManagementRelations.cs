using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class ModifiedTestCenterManagementRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenterManagement_TestCenters_ManagedTestCenterName",
                table: "TestCenterManagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCenterManagement",
                table: "TestCenterManagement");

            migrationBuilder.DropIndex(
                name: "IX_TestCenterManagement_ManagedTestCenterName",
                table: "TestCenterManagement");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TestCenterManagement");

            migrationBuilder.DropColumn(
                name: "ManagedTestCenterName",
                table: "TestCenterManagement");

            migrationBuilder.AddColumn<string>(
                name: "ManagementName",
                table: "TestCenters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestCenterManagement",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCenterManagement",
                table: "TestCenterManagement",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenters_ManagementName",
                table: "TestCenters",
                column: "ManagementName");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenters_TestCenterManagement_ManagementName",
                table: "TestCenters",
                column: "ManagementName",
                principalTable: "TestCenterManagement",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCenters_TestCenterManagement_ManagementName",
                table: "TestCenters");

            migrationBuilder.DropIndex(
                name: "IX_TestCenters_ManagementName",
                table: "TestCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCenterManagement",
                table: "TestCenterManagement");

            migrationBuilder.DropColumn(
                name: "ManagementName",
                table: "TestCenters");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestCenterManagement");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TestCenterManagement",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ManagedTestCenterName",
                table: "TestCenterManagement",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCenterManagement",
                table: "TestCenterManagement",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TestCenterManagement_ManagedTestCenterName",
                table: "TestCenterManagement",
                column: "ManagedTestCenterName",
                unique: true,
                filter: "[ManagedTestCenterName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCenterManagement_TestCenters_ManagedTestCenterName",
                table: "TestCenterManagement",
                column: "ManagedTestCenterName",
                principalTable: "TestCenters",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
