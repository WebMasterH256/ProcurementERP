using System;
using System.Collections.Generic;
using System.Text;

namespace Domain;

public class Fornecedor
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Cnpj { get; set; }
	public string Email { get; set; }
	public long Telefone { get; set; }
	public ICollection<Produto> Produtos { get; set; }
}
