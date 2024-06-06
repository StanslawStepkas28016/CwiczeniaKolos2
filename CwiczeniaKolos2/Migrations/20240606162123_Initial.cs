using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolos2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Muzyk_pk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Wytwornia",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Wytwornia_pk", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Album_pk", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "Album_Wytwornia",
                        column: x => x.IdWytwornia,
                        principalTable: "Wytwornia",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utwor",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Utwor_pk", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "Utwor_Album",
                        column: x => x.IdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WykonawcaUtworu",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WykonwacaUtworu_pk", x => new { x.IdMuzyk, x.IdUtwor });
                    table.ForeignKey(
                        name: "WykonawcaUtworu_Muzyk",
                        column: x => x.IdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "WykonawcaUtworu_Utwor",
                        column: x => x.IdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdWytwornia",
                table: "Album",
                column: "IdWytwornia");

            migrationBuilder.CreateIndex(
                name: "IX_Utwor_IdAlbum",
                table: "Utwor",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_WykonawcaUtworu_IdUtwor",
                table: "WykonawcaUtworu",
                column: "IdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawcaUtworu");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Utwor");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Wytwornia");
        }
    }
}
