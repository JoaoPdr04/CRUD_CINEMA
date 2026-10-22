using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaRepository.Migrations
{
    /// <inheritdoc />
    public partial class AjusteMapeamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SALA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CAPACIDADE = table.Column<int>(type: "integer", nullable: false),
                    NUMERO = table.Column<int>(type: "integer", nullable: false),
                    FILEIRAS = table.Column<int>(type: "integer", nullable: false),
                    ASSENTOS = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOVIE",
                columns: table => new
                {
                    NOME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Classificacao = table.Column<string>(type: "text", nullable: false),
                    GeneroId = table.Column<int>(type: "integer", nullable: false),
                    DURACAO = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIE", x => x.NOME);
                    table.ForeignKey(
                        name: "FK_MOVIE_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SESSAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    FilmeNome = table.Column<string>(type: "character varying(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SESSAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SESSAO_MOVIE_FilmeNome",
                        column: x => x.FilmeNome,
                        principalTable: "MOVIE",
                        principalColumn: "NOME",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SESSAO_SALA_SalaId",
                        column: x => x.SalaId,
                        principalTable: "SALA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Documento = table.Column<string>(type: "text", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SessaoId = table.Column<int>(type: "integer", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    FormaPagamento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresso_SESSAO_SessaoId",
                        column: x => x.SessaoId,
                        principalTable: "SESSAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INGRESSO_ITEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Assento = table.Column<int>(type: "integer", nullable: false),
                    Fileira = table.Column<int>(type: "integer", nullable: false),
                    IngressoId = table.Column<int>(type: "integer", nullable: false),
                    MeiaEntrada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGRESSO_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_INGRESSO_ITEM_Ingresso_IngressoId",
                        column: x => x.IngressoId,
                        principalTable: "Ingresso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_SessaoId",
                table: "Ingresso",
                column: "SessaoId");

            migrationBuilder.CreateIndex(
                name: "IX_INGRESSO_ITEM_IngressoId",
                table: "INGRESSO_ITEM",
                column: "IngressoId");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIE_GeneroId",
                table: "MOVIE",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_SESSAO_FilmeNome",
                table: "SESSAO",
                column: "FilmeNome");

            migrationBuilder.CreateIndex(
                name: "IX_SESSAO_SalaId",
                table: "SESSAO",
                column: "SalaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INGRESSO_ITEM");

            migrationBuilder.DropTable(
                name: "Ingresso");

            migrationBuilder.DropTable(
                name: "SESSAO");

            migrationBuilder.DropTable(
                name: "MOVIE");

            migrationBuilder.DropTable(
                name: "SALA");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
