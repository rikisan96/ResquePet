using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResquePet.Migrations
{
    /// <inheritdoc />
    public partial class AnimaliMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.IdUtente);
                });

            migrationBuilder.CreateTable(
                name: "animale",
                columns: table => new
                {
                    IdAnimale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoAnimale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coloreMantello = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataNascita = table.Column<DateOnly>(type: "date", nullable: false),
                    isMicrochipped = table.Column<bool>(type: "bit", nullable: false),
                    MicrochipID = table.Column<int>(type: "int", nullable: true),
                    IdUtente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animale", x => x.IdAnimale);
                    table.ForeignKey(
                        name: "FK_animale_Utente_IdUtente",
                        column: x => x.IdUtente,
                        principalTable: "Utente",
                        principalColumn: "IdUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animale_IdUtente",
                table: "animale",
                column: "IdUtente",
                unique: true,
                filter: "[IdUtente] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animale");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
