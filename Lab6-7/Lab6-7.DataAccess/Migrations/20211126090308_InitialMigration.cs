using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab6_7.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Contacts = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TechSkills = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SoftSkills = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemoVersion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Media = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Documentation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Repository = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
