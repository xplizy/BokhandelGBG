using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BokhandelGBG.Migrations
{
    /// <inheritdoc />
    public partial class UppdateringFörForfattare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Butiker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Butiksnamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Adress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Butiker__3214EC27CF608227", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Författare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Efternamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Födelsedatum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Författa__3214EC273577E4F4", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Förlag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förlagsnam = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Adress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Förlag__3214EC2781E2078D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Efternamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Adress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kunder__3214EC27A2EA265E", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Böcker",
                columns: table => new
                {
                    ISBN13 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Titel = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Språk = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Pris = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Utgivningsdatum = table.Column<DateTime>(type: "date", nullable: true),
                    FörfattareID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Böcker__3BF79E036095685B", x => x.ISBN13);
                    table.ForeignKey(
                        name: "FK__Böcker__Författa__267ABA7A",
                        column: x => x.FörfattareID,
                        principalTable: "Författare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ordrar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    KundID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ordrar__3214EC2798287976", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Ordrar__KundID__30F848ED",
                        column: x => x.KundID,
                        principalTable: "Kunder",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BokFörlag",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "varchar(255)", nullable: false),
                    FörlagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BokFörla__999B9EB9CD8DD297", x => new { x.Isbn, x.FörlagId });
                    table.ForeignKey(
                        name: "FK__BokFörlag__Förla__36B12243",
                        column: x => x.FörlagId,
                        principalTable: "Förlag",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__BokFörlag__ISBN__35BCFE0A",
                        column: x => x.Isbn,
                        principalTable: "Böcker",
                        principalColumn: "ISBN13");
                });

            migrationBuilder.CreateTable(
                name: "LagerStatus",
                columns: table => new
                {
                    ButikID = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LagerSta__1191B8948D5CE6CE", x => new { x.ButikID, x.ISBN });
                    table.ForeignKey(
                        name: "FK__LagerStat__Butik__2B3F6F97",
                        column: x => x.ButikID,
                        principalTable: "Butiker",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__LagerStatu__ISBN__2C3393D0",
                        column: x => x.ISBN,
                        principalTable: "Böcker",
                        principalColumn: "ISBN13");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BokFörlag_FörlagId",
                table: "BokFörlag",
                column: "FörlagId");

            migrationBuilder.CreateIndex(
                name: "IX_Böcker_FörfattareID",
                table: "Böcker",
                column: "FörfattareID");

            migrationBuilder.CreateIndex(
                name: "IX_LagerStatus_ISBN",
                table: "LagerStatus",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_KundID",
                table: "Ordrar",
                column: "KundID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BokFörlag");

            migrationBuilder.DropTable(
                name: "LagerStatus");

            migrationBuilder.DropTable(
                name: "Ordrar");

            migrationBuilder.DropTable(
                name: "Förlag");

            migrationBuilder.DropTable(
                name: "Butiker");

            migrationBuilder.DropTable(
                name: "Böcker");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Författare");
        }
    }
}
