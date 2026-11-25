using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaRepository.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaIngresso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_SESSAO_SessaoId",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_INGRESSO_ITEM_Ingresso_IngressoId",
                table: "INGRESSO_ITEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingresso",
                table: "Ingresso");

            migrationBuilder.RenameTable(
                name: "Ingresso",
                newName: "INGRESSO");

            migrationBuilder.RenameIndex(
                name: "IX_Ingresso_SessaoId",
                table: "INGRESSO",
                newName: "IX_INGRESSO_SessaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_INGRESSO",
                table: "INGRESSO",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_INGRESSO_SESSAO_SessaoId",
                table: "INGRESSO",
                column: "SessaoId",
                principalTable: "SESSAO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_INGRESSO_ITEM_INGRESSO_IngressoId",
                table: "INGRESSO_ITEM",
                column: "IngressoId",
                principalTable: "INGRESSO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INGRESSO_SESSAO_SessaoId",
                table: "INGRESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_INGRESSO_ITEM_INGRESSO_IngressoId",
                table: "INGRESSO_ITEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_INGRESSO",
                table: "INGRESSO");

            migrationBuilder.RenameTable(
                name: "INGRESSO",
                newName: "Ingresso");

            migrationBuilder.RenameIndex(
                name: "IX_INGRESSO_SessaoId",
                table: "Ingresso",
                newName: "IX_Ingresso_SessaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingresso",
                table: "Ingresso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_SESSAO_SessaoId",
                table: "Ingresso",
                column: "SessaoId",
                principalTable: "SESSAO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_INGRESSO_ITEM_Ingresso_IngressoId",
                table: "INGRESSO_ITEM",
                column: "IngressoId",
                principalTable: "Ingresso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
