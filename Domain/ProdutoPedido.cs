using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain;

public class ProdutoPedido
{
	public int Id { get; set; }
	public short Quantidade { get; set; }
	public decimal? PrecoUnitario { get; set; }

	[ForeignKey("Pedido")]
	public int PedidoId { get; set; }
	public Pedido Pedido { get; set; }
	[ForeignKey("Produto")]
	public int ProdutoId { get; set; }
	public Produto Produto { get; set; }
}
