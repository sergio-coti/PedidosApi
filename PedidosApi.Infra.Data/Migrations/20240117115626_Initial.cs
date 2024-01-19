using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosApi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataHoraPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    StatusPedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCartao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataExpiracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoSeguranca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processado = table.Column<bool>(type: "bit", nullable: true),
                    DataHoraProcessamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodigoProcessamento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValorProcessamento = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_PedidoId",
                table: "Pagamento",
                column: "PedidoId",
                unique: true,
                filter: "[PedidoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodigoPedido",
                table: "Pedido",
                column: "CodigoPedido",
                unique: true,
                filter: "[CodigoPedido] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
