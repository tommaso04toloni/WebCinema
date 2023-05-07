using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCinema.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prenotazioni_posti_IdpostoNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_prenotazioni_spettacoli_IdspettacoloNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_prenotazioni_utenti_IdutenteNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropTable(
                name: "filmcategorie");

            migrationBuilder.DropTable(
                name: "categorie");

            migrationBuilder.DropIndex(
                name: "IX_prenotazioni_IdpostoNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropIndex(
                name: "IX_prenotazioni_IdspettacoloNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropIndex(
                name: "IX_prenotazioni_IdutenteNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropColumn(
                name: "IdpostoNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropColumn(
                name: "IdspettacoloNavigationId",
                table: "prenotazioni");

            migrationBuilder.DropColumn(
                name: "IdutenteNavigationId",
                table: "prenotazioni");

            migrationBuilder.RenameIndex(
                name: "IDFilm2",
                table: "valutazioni",
                newName: "IDFilm1");

            migrationBuilder.RenameIndex(
                name: "IDFilm1",
                table: "spettacoli",
                newName: "IDFilm");

            migrationBuilder.AddForeignKey(
                name: "prenotazioni_ibfk_1",
                table: "prenotazioni",
                column: "IDUtente",
                principalTable: "utenti",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "prenotazioni_ibfk_2",
                table: "prenotazioni",
                column: "IDSpettacolo",
                principalTable: "spettacoli",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "prenotazioni_ibfk_3",
                table: "prenotazioni",
                column: "IDPosto",
                principalTable: "posti",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "prenotazioni_ibfk_1",
                table: "prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "prenotazioni_ibfk_2",
                table: "prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "prenotazioni_ibfk_3",
                table: "prenotazioni");

            migrationBuilder.RenameIndex(
                name: "IDFilm1",
                table: "valutazioni",
                newName: "IDFilm2");

            migrationBuilder.RenameIndex(
                name: "IDFilm",
                table: "spettacoli",
                newName: "IDFilm1");

            migrationBuilder.AddColumn<uint>(
                name: "IdpostoNavigationId",
                table: "prenotazioni",
                type: "int(10) unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "IdspettacoloNavigationId",
                table: "prenotazioni",
                type: "int(10) unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "IdutenteNavigationId",
                table: "prenotazioni",
                type: "int(10) unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateTable(
                name: "categorie",
                columns: table => new
                {
                    ID = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "filmcategorie",
                columns: table => new
                {
                    ID = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDCategoria = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    IDFilm = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ID);
                    table.ForeignKey(
                        name: "filmcategorie_ibfk_1",
                        column: x => x.IDFilm,
                        principalTable: "film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "filmcategorie_ibfk_2",
                        column: x => x.IDCategoria,
                        principalTable: "categorie",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateIndex(
                name: "IX_prenotazioni_IdpostoNavigationId",
                table: "prenotazioni",
                column: "IdpostoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_prenotazioni_IdspettacoloNavigationId",
                table: "prenotazioni",
                column: "IdspettacoloNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_prenotazioni_IdutenteNavigationId",
                table: "prenotazioni",
                column: "IdutenteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IDCategoria",
                table: "filmcategorie",
                column: "IDCategoria");

            migrationBuilder.CreateIndex(
                name: "IDFilm",
                table: "filmcategorie",
                column: "IDFilm");

            migrationBuilder.AddForeignKey(
                name: "FK_prenotazioni_posti_IdpostoNavigationId",
                table: "prenotazioni",
                column: "IdpostoNavigationId",
                principalTable: "posti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prenotazioni_spettacoli_IdspettacoloNavigationId",
                table: "prenotazioni",
                column: "IdspettacoloNavigationId",
                principalTable: "spettacoli",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prenotazioni_utenti_IdutenteNavigationId",
                table: "prenotazioni",
                column: "IdutenteNavigationId",
                principalTable: "utenti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
