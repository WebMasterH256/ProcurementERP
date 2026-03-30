using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStructure.Migrations
{
		/// <inheritdoc />
		public partial class InitialCreate : Migration
		{
				/// <inheritdoc />
				protected override void Up(MigrationBuilder migrationBuilder)
				{
						migrationBuilder.CreateTable(
								name: "Departamento",
								columns: table => new
								{
										Id = table.Column<int>(type: "int", nullable: false)
												.Annotation("SqlServer:Identity", "1, 1"),
										Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
										Orcamento = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false)
								},
								constraints: table =>
								{
										table.PrimaryKey("PK_Departamento", x => x.Id);
								});

						migrationBuilder.CreateTable(
								name: "Fornecedor",
								columns: table => new
								{
										Id = table.Column<int>(type: "int", nullable: false)
												.Annotation("SqlServer:Identity", "1, 1"),
										Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
										Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
										Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
										Telefone = table.Column<long>(type: "bigint", nullable: false)
								},
								constraints: table =>
								{
										table.PrimaryKey("PK_Fornecedor", x => x.Id);
								});

						migrationBuilder.CreateTable(
								name: "Usuario",
								columns: table => new
								{
										Id = table.Column<int>(type: "int", nullable: false)
												.Annotation("SqlServer:Identity", "1, 1"),
										Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
										Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
										Senha = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
										Cargo = table.Column<int>(type: "int", nullable: false),
										DepartamentoId = table.Column<int>(type: "int", nullable: false)
								},
								constraints: table =>
								{
										table.PrimaryKey("PK_Usuario", x => x.Id);
										table.ForeignKey(
												name: "FK_Usuario_Departamento_DepartamentoId",
												column: x => x.DepartamentoId,
												principalTable: "Departamento",
												principalColumn: "Id",
												onDelete: ReferentialAction.Restrict);
								});

						migrationBuilder.CreateTable(
								name: "Produto",
								columns: table => new
								{
										Id = table.Column<int>(type: "int", nullable: false)
												.Annotation("SqlServer:Identity", "1, 1"),
										Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
										PrecoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
										Descricao = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
										FornecedorId = table.Column<int>(type: "int", nullable: false)
								},
								constraints: table =>
								{
										table.PrimaryKey("PK_Produto", x => x.Id);
										table.ForeignKey(
												name: "FK_Produto_Fornecedor_FornecedorId",
												column: x => x.FornecedorId,
												principalTable: "Fornecedor",
												principalColumn: "Id",
												onDelete: ReferentialAction.Restrict);
								});

						migrationBuilder.CreateTable(
								name: "Pedido",
								columns: table => new
								{
										Id = table.Column<int>(type: "int", nullable: false)
												.Annotation("SqlServer:Identity", "1, 1"),
										Criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
										Status = table.Column<int>(type: "int", nullable: false),
										Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
										UsuarioId = table.Column<int>(type: "int", nullable: false),
										DepartamentoId = table.Column<int>(type: "int", nullable: false)
								},
								constraints: table =>
								{
										table.PrimaryKey("PK_Pedido", x => x.Id);
										table.ForeignKey(
												name: "FK_Pedido_Departamento_DepartamentoId",
												column: x => x.DepartamentoId,
												principalTable: "Departamento",
												principalColumn: "Id",
												onDelete: ReferentialAction.Cascade);
										table.ForeignKey(
												name: "FK_Pedido_Usuario_UsuarioId",
												column: x => x.UsuarioId,
												principalTable: "Usuario",
												principalColumn: "Id",
												onDelete: ReferentialAction.Restrict);
								});

						migrationBuilder.CreateTable(
								name: "ProdutoPedido",
								columns: table => new
								{
										Id = table.Column<int>(type: "int", nullable: false)
												.Annotation("SqlServer:Identity", "1, 1"),
										Quantidade = table.Column<short>(type: "smallint", nullable: false),
										PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
										PedidoId = table.Column<int>(type: "int", nullable: false),
										ProdutoId = table.Column<int>(type: "int", nullable: false)
								},
								constraints: table =>
								{
										table.PrimaryKey("PK_ProdutoPedido", x => x.Id);
										table.ForeignKey(
												name: "FK_ProdutoPedido_Pedido_PedidoId",
												column: x => x.PedidoId,
												principalTable: "Pedido",
												principalColumn: "Id",
												onDelete: ReferentialAction.Restrict);
										table.ForeignKey(
												name: "FK_ProdutoPedido_Produto_ProdutoId",
												column: x => x.ProdutoId,
												principalTable: "Produto",
												principalColumn: "Id",
												onDelete: ReferentialAction.Restrict);
								});

						migrationBuilder.CreateIndex(
								name: "IX_Pedido_DepartamentoId",
								table: "Pedido",
								column: "DepartamentoId");

						migrationBuilder.CreateIndex(
								name: "IX_Pedido_UsuarioId",
								table: "Pedido",
								column: "UsuarioId");

						migrationBuilder.CreateIndex(
								name: "IX_Produto_FornecedorId",
								table: "Produto",
								column: "FornecedorId");

						migrationBuilder.CreateIndex(
								name: "IX_ProdutoPedido_PedidoId",
								table: "ProdutoPedido",
								column: "PedidoId");

						migrationBuilder.CreateIndex(
								name: "IX_ProdutoPedido_ProdutoId",
								table: "ProdutoPedido",
								column: "ProdutoId");

						migrationBuilder.CreateIndex(
								name: "IX_Usuario_DepartamentoId",
								table: "Usuario",
								column: "DepartamentoId");
				}

				/// <inheritdoc />
				protected override void Down(MigrationBuilder migrationBuilder)
				{
						migrationBuilder.DropTable(
								name: "ProdutoPedido");

						migrationBuilder.DropTable(
								name: "Pedido");

						migrationBuilder.DropTable(
								name: "Produto");

						migrationBuilder.DropTable(
								name: "Usuario");

						migrationBuilder.DropTable(
								name: "Fornecedor");

						migrationBuilder.DropTable(
								name: "Departamento");
				}
		}
}
