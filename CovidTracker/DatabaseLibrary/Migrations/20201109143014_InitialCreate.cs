using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    SSN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Municipalities");
        }
    }
}
