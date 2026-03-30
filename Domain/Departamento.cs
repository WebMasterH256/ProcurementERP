namespace Domain;

public class Departamento
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public double Orcamento { get; set; }
	public ICollection<Usuario> Usuarios { get; set; }
	public ICollection<Pedido> Pedidos  { get; set; }
}
