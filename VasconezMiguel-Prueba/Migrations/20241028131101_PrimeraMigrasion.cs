using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VasconezMiguel_Prueba.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigrasion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MVasconez",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    peso = table.Column<float>(type: "real", nullable: false),
                    Compra = table.Column<bool>(type: "bit", nullable: false),
                    IdCelular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVasconez", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MVasconez_Celular_IdCelular",
                        column: x => x.IdCelular,
                        principalTable: "Celular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MVasconez_IdCelular",
                table: "MVasconez",
                column: "IdCelular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MVasconez");

            migrationBuilder.DropTable(
                name: "Celular");
        }
    }
}
