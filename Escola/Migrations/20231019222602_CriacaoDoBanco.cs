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
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
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
                    UsuInclusaoId = table.Column<int>(type: "int", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuUltAtuId = table.Column<int>(type: "int", nullable: true),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuExclusaoId = table.Column<int>(type: "int", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Usuarios_UsuExclusaoId",
                        column: x => x.UsuExclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pessoas_Usuarios_UsuInclusaoId",
                        column: x => x.UsuInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pessoas_Usuarios_UsuUltAtuId",
                        column: x => x.UsuUltAtuId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Ra = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataRecisao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UsuInclusaoId = table.Column<int>(type: "int", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuUltAtuId = table.Column<int>(type: "int", nullable: true),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuExclusaoId = table.Column<int>(type: "int", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_UsuExclusaoId",
                        column: x => x.UsuExclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_UsuInclusaoId",
                        column: x => x.UsuInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_UsuUltAtuId",
                        column: x => x.UsuUltAtuId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Numero = table.Column<int>(type: "INT", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    UsuInclusaoId = table.Column<int>(type: "int", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuUltAtuId = table.Column<int>(type: "int", nullable: true),
                    DataUltAtu = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuExclusaoId = table.Column<int>(type: "int", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuExclusaoId",
                        column: x => x.UsuExclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuInclusaoId",
                        column: x => x.UsuInclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuUltAtuId",
                        column: x => x.UsuUltAtuId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Alunos_Ra",
                table: "Alunos",
                column: "Ra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PessoaId",
                table: "Alunos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UsuExclusaoId",
                table: "Alunos",
                column: "UsuExclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UsuInclusaoId",
                table: "Alunos",
                column: "UsuInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UsuUltAtuId",
                table: "Alunos",
                column: "UsuUltAtuId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuExclusaoId",
                table: "Enderecos",
                column: "UsuExclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuInclusaoId",
                table: "Enderecos",
                column: "UsuInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuUltAtuId",
                table: "Enderecos",
                column: "UsuUltAtuId");

            migrationBuilder.CreateIndex(
                name: "IDX_Pessoas_Cpf",
                table: "Pessoas",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_UsuExclusaoId",
                table: "Pessoas",
                column: "UsuExclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_UsuInclusaoId",
                table: "Pessoas",
                column: "UsuInclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_UsuUltAtuId",
                table: "Pessoas",
                column: "UsuUltAtuId");
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
