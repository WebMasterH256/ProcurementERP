using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain;

public enum Posicao
{
	Funcionario,
	Gerente
}

public class Usuario
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Senha { get; set; }
	public Posicao Cargo { get; set; }
	public ICollection<Pedido> Pedidos { get; set; }

	[ForeignKey("Departamento")]
	public int DepartamentoId { get; set; }
	public Departamento Departamento { get; set; }

}
