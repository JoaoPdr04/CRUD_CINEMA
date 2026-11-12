using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaRepository.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MOVIE_Genero_GeneroId",
                table: "MOVIE");

            migrationBuilder.DropForeignKey(
                name: "FK_SESSAO_MOVIE_FilmeNome",
                table: "SESSAO");

            migrationBuilder.DropIndex(
                name: "IX_SESSAO_FilmeNome",
                table: "SESSAO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MOVIE",
                table: "MOVIE");

            migrationBuilder.DropColumn(
                name: "FilmeNome",
                table: "SESSAO");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "SESSAO",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MOVIE",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MOVIE",
                table: "MOVIE",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SESSAO_FilmeId",
                table: "SESSAO",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MOVIE_Genero_GeneroId",
                table: "MOVIE",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SESSAO_MOVIE_FilmeId",
                table: "SESSAO",
                column: "FilmeId",
                principalTable: "MOVIE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MOVIE_Genero_GeneroId",
                table: "MOVIE");

            migrationBuilder.DropForeignKey(
                name: "FK_SESSAO_MOVIE_FilmeId",
                table: "SESSAO");

            migrationBuilder.DropIndex(
                name: "IX_SESSAO_FilmeId",
                table: "SESSAO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MOVIE",
                table: "MOVIE");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "SESSAO");

            migrationBuilder.AddColumn<string>(
                name: "FilmeNome",
                table: "SESSAO",
                type: "character varying(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MOVIE",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MOVIE",
                table: "MOVIE",
                column: "NOME");

            migrationBuilder.CreateIndex(
                name: "IX_SESSAO_FilmeNome",
                table: "SESSAO",
                column: "FilmeNome");

            migrationBuilder.AddForeignKey(
                name: "FK_MOVIE_Genero_GeneroId",
                table: "MOVIE",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SESSAO_MOVIE_FilmeNome",
                table: "SESSAO",
                column: "FilmeNome",
                principalTable: "MOVIE",
                principalColumn: "NOME",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
