using System;
using System.Collections.Generic;
using System.Text;

namespace Domain;

public class AuditLog
{
	public int Id { get; set; }
	public DateTime Data { get; set; }
	public int PedidoId { get; set; }
	public string StatusAnterior { get; set; }
	public string StatusNovo { get; set; }
	public int UsuarioId { get; set; }
}
