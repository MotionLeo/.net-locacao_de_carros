using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocacaoDeCarros.Migrations
{
    public partial class AplicandoChaveEstrangeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_marca",
                table: "modelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_carro",
                table: "pedidos",
                column: "id_carro");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_cliente",
                table: "pedidos",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_modelos_id_marca",
                table: "modelos",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_carros_id_marca",
                table: "carros",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_carros_id_modelo",
                table: "carros",
                column: "id_modelo");

            migrationBuilder.AddForeignKey(
                name: "FK_carros_marcas_id_marca",
                table: "carros",
                column: "id_marca",
                principalTable: "marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carros_modelos_id_modelo",
                table: "carros",
                column: "id_modelo",
                principalTable: "modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modelos_marcas_id_marca",
                table: "modelos",
                column: "id_marca",
                principalTable: "marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_carros_id_carro",
                table: "pedidos",
                column: "id_carro",
                principalTable: "carros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos",
                column: "id_cliente",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carros_marcas_id_marca",
                table: "carros");

            migrationBuilder.DropForeignKey(
                name: "FK_carros_modelos_id_modelo",
                table: "carros");

            migrationBuilder.DropForeignKey(
                name: "FK_modelos_marcas_id_marca",
                table: "modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_carros_id_carro",
                table: "pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_clientes_id_cliente",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_id_carro",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_id_cliente",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_modelos_id_marca",
                table: "modelos");

            migrationBuilder.DropIndex(
                name: "IX_carros_id_marca",
                table: "carros");

            migrationBuilder.DropIndex(
                name: "IX_carros_id_modelo",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "id_marca",
                table: "modelos");
        }
    }
}
