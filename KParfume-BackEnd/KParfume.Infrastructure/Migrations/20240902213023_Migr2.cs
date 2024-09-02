using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KParfume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "KParfumeSchema",
                newName: "Korisnik",
                newSchema: "KParfumeSchema");

            migrationBuilder.RenameIndex(
                name: "IX_Users_kor_email",
                schema: "KParfumeSchema",
                table: "Korisnik",
                newName: "IX_Korisnik_kor_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnik",
                schema: "KParfumeSchema",
                table: "Korisnik",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnik",
                schema: "KParfumeSchema",
                table: "Korisnik");

            migrationBuilder.RenameTable(
                name: "Korisnik",
                schema: "KParfumeSchema",
                newName: "Users",
                newSchema: "KParfumeSchema");

            migrationBuilder.RenameIndex(
                name: "IX_Korisnik_kor_email",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "IX_Users_kor_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "KParfumeSchema",
                table: "Users",
                column: "Id");
        }
    }
}
