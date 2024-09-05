using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KParfume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "KParfumeSchema");

            migrationBuilder.CreateTable(
                name: "Fabrika",
                schema: "KParfumeSchema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fab_naziv = table.Column<string>(type: "text", nullable: false),
                    fab_adresa = table.Column<string>(type: "text", nullable: false),
                    fab_grad = table.Column<string>(type: "text", nullable: false),
                    fab_pos_br = table.Column<int>(type: "integer", nullable: false),
                    fab_drzava = table.Column<string>(type: "text", nullable: false),
                    fab_vreme_od = table.Column<string>(type: "text", nullable: false),
                    fab_vreme_do = table.Column<string>(type: "text", nullable: false),
                    fab_tel = table.Column<string>(type: "text", nullable: false),
                    fab_logo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                schema: "KParfumeSchema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kor_email = table.Column<string>(type: "text", nullable: false),
                    kor_lozinka = table.Column<string>(type: "text", nullable: false),
                    kor_uloga = table.Column<int>(type: "integer", nullable: false),
                    kor_ime = table.Column<string>(type: "text", nullable: false),
                    kor_prezime = table.Column<string>(type: "text", nullable: false),
                    kor_adresa = table.Column<string>(type: "text", nullable: false),
                    kor_grad = table.Column<string>(type: "text", nullable: false),
                    kor_pos_br = table.Column<int>(type: "integer", nullable: false),
                    kor_drzava = table.Column<string>(type: "text", nullable: false),
                    kor_tel = table.Column<string>(type: "text", nullable: false),
                    kor_fab_id = table.Column<long>(type: "bigint", nullable: true),
                    kor_ime_kompanije = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Fabrika_kor_fab_id",
                        column: x => x.kor_fab_id,
                        principalSchema: "KParfumeSchema",
                        principalTable: "Fabrika",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_kor_email",
                schema: "KParfumeSchema",
                table: "Korisnik",
                column: "kor_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_kor_fab_id",
                schema: "KParfumeSchema",
                table: "Korisnik",
                column: "kor_fab_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik",
                schema: "KParfumeSchema");

            migrationBuilder.DropTable(
                name: "Fabrika",
                schema: "KParfumeSchema");
        }
    }
}
