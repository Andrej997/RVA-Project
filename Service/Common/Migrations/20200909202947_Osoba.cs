using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class Osoba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vezbac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Osoba");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Osoba",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Osoba",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Osoba",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Osoba",
                table: "Osoba",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Osoba",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Osoba");

            migrationBuilder.RenameTable(
                name: "Osoba",
                newName: "Admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Vezbac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vezbac", x => x.Id);
                });
        }
    }
}
