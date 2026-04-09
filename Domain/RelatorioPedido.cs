namespace Domain;

public class RelatorioPedido
{
	public int PedidoId { get; set; }
	public string Departamento { get; set; }
	public string Usuario { get; set; }
	public string Status { get; set; }
	public decimal ValorTotal { get; set; }
	public DateTime DataCriacao { get; set; }
}
