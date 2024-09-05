using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KParfume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migr3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fabrika",
                schema: "KParfumeSchema");
        }
    }
}
