using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    public partial class CriacaoDoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    Ra = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataRecisao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UsuInclusaoId = table.Column<int>(type: "INT", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuUltAtuId = table.Column<int>(type: "INT", nullable: false),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuExclusaoId = table.Column<int>(type: "INT", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Numero = table.Column<int>(type: "INT", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    UsuInclusaoId = table.Column<int>(type: "INT", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuUltAtuId = table.Column<int>(type: "INT", nullable: false),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuExclusaoId = table.Column<int>(type: "INT", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    UsuInclusaoId = table.Column<int>(type: "INT", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuUltAtuId = table.Column<int>(type: "INT", nullable: false),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuExclusaoId = table.Column<int>(type: "INT", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Alunos_Ra",
                table: "Alunos",
                column: "Ra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_Pessoas_Cpf",
                table: "Pessoas",
                column: "Cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
