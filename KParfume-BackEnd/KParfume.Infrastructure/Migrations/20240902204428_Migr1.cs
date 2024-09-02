using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KParfume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "kor_tel");

            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "kor_uloga");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "kor_prezime");

            migrationBuilder.AddColumn<string>(
                name: "kor_adresa",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "kor_drzava",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "kor_email",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "kor_fab_id",
                schema: "KParfumeSchema",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kor_grad",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "kor_ime",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "kor_ime_kompanije",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kor_lozinka",
                schema: "KParfumeSchema",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "kor_pos_br",
                schema: "KParfumeSchema",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_kor_email",
                schema: "KParfumeSchema",
                table: "Users",
                column: "kor_email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_kor_email",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_adresa",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_drzava",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_email",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_fab_id",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_grad",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_ime",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_ime_kompanije",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_lozinka",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "kor_pos_br",
                schema: "KParfumeSchema",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "kor_uloga",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "kor_tel",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "kor_prezime",
                schema: "KParfumeSchema",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "KParfumeSchema",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "KParfumeSchema",
                table: "Users",
                column: "Username",
                unique: true);
        }
    }
}
