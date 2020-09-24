using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "Trening",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrenerID",
                table: "Trening",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VezbacID",
                table: "Trening",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trening_AdminID",
                table: "Trening",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TrenerID",
                table: "Trening",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_VezbacID",
                table: "Trening",
                column: "VezbacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_Admin_AdminID",
                table: "Trening",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_Trener_TrenerID",
                table: "Trening",
                column: "TrenerID",
                principalTable: "Trener",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_Vezbac_VezbacID",
                table: "Trening",
                column: "VezbacID",
                principalTable: "Vezbac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trening_Admin_AdminID",
                table: "Trening");

            migrationBuilder.DropForeignKey(
                name: "FK_Trening_Trener_TrenerID",
                table: "Trening");

            migrationBuilder.DropForeignKey(
                name: "FK_Trening_Vezbac_VezbacID",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_Trening_AdminID",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_Trening_TrenerID",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_Trening_VezbacID",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "TrenerID",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "VezbacID",
                table: "Trening");
        }
    }
}
