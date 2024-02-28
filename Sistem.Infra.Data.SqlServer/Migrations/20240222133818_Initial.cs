using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistem.Infra.Data.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Nome",
                table: "Produtos",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Quantidade",
                table: "Produtos",
                column: "Quantidade");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Tipo",
                table: "Produtos",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Valor",
                table: "Produtos",
                column: "Valor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
