using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain;

public class Produto
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public decimal? PrecoAtual { get; set; }
	public string Descricao { get; set; }

	public ICollection<ProdutoPedido> ProdutosPedidos { get; set; }

	[ForeignKey("Fornecedor")]
	public int FornecedorId { get; set; }
	public Fornecedor Fornecedor { get; set; }
}
