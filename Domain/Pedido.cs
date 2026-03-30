using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain;

public enum StatusPedido
{
	Aberto,
	Finalizado,
	Cancelado
}

public class Pedido
{
	public int Id { get; set; }
	public DateTime Criacao { get; set; }
	public StatusPedido Status { get; set; }
	public decimal Valor { get; set; }

	public ICollection<ProdutoPedido> Produtos { get; set; }


	[ForeignKey("Usuario")]
	public int UsuarioId { get; set; }
	public Usuario Usuario { get; set; }
	[ForeignKey("Departamento")]
	public int DepartamentoId { get; set; }
	public Departamento Departamento { get; set; }
}
