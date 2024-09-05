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
                name: "Kategorija_parfema",
                schema: "KParfumeSchema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kp_naziv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija_parfema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tip_parfema",
                schema: "KParfumeSchema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tp_naziv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip_parfema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vrsta_parfema",
                schema: "KParfumeSchema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vp_naziv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrsta_parfema", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Parfem",
                schema: "KParfumeSchema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    par_naziv = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    par_opis = table.Column<string>(type: "text", nullable: false),
                    par_slika = table.Column<string>(type: "text", nullable: false),
                    par_kolicina = table.Column<int>(type: "integer", nullable: false),
                    par_mililitraza = table.Column<double>(type: "double precision", nullable: false),
                    par_dostupan = table.Column<bool>(type: "boolean", nullable: false),
                    par_obrisan = table.Column<bool>(type: "boolean", nullable: false),
                    par_fab_id = table.Column<long>(type: "bigint", nullable: false),
                    par_vp_id = table.Column<long>(type: "bigint", nullable: false),
                    par_tp_id = table.Column<long>(type: "bigint", nullable: false),
                    par_kp_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parfem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parfem_Fabrika_par_fab_id",
                        column: x => x.par_fab_id,
                        principalSchema: "KParfumeSchema",
                        principalTable: "Fabrika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parfem_Kategorija_parfema_par_kp_id",
                        column: x => x.par_kp_id,
                        principalSchema: "KParfumeSchema",
                        principalTable: "Kategorija_parfema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parfem_Tip_parfema_par_tp_id",
                        column: x => x.par_tp_id,
                        principalSchema: "KParfumeSchema",
                        principalTable: "Tip_parfema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parfem_Vrsta_parfema_par_vp_id",
                        column: x => x.par_vp_id,
                        principalSchema: "KParfumeSchema",
                        principalTable: "Vrsta_parfema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Parfem_par_fab_id",
                schema: "KParfumeSchema",
                table: "Parfem",
                column: "par_fab_id");

            migrationBuilder.CreateIndex(
                name: "IX_Parfem_par_kp_id",
                schema: "KParfumeSchema",
                table: "Parfem",
                column: "par_kp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Parfem_par_tp_id",
                schema: "KParfumeSchema",
                table: "Parfem",
                column: "par_tp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Parfem_par_vp_id",
                schema: "KParfumeSchema",
                table: "Parfem",
                column: "par_vp_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik",
                schema: "KParfumeSchema");

            migrationBuilder.DropTable(
                name: "Parfem",
                schema: "KParfumeSchema");

            migrationBuilder.DropTable(
                name: "Fabrika",
                schema: "KParfumeSchema");

            migrationBuilder.DropTable(
                name: "Kategorija_parfema",
                schema: "KParfumeSchema");

            migrationBuilder.DropTable(
                name: "Tip_parfema",
                schema: "KParfumeSchema");

            migrationBuilder.DropTable(
                name: "Vrsta_parfema",
                schema: "KParfumeSchema");
        }
    }
}
