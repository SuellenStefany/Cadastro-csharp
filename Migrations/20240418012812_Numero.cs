using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class Numero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.AlterTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false),
                    Documento = table.Column<string>(type: "longtext", nullable: false),
                    Cep = table.Column<string>(type: "longtext", nullable: false),
                    Endereco = table.Column<string>(type: "longtext", nullable: false),
                    Logradouro = table.Column<string>(type: "longtext", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Uf = table.Column<string>(type: "longtext", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
