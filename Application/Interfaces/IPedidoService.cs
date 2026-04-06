using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IPedidoService
{
	Task<IEnumerable<Pedido>> GetAllAsync();
	Task<Pedido?> GetByIdAsync(int id);
	Task AddAsync(Pedido pedido);
	Task UpdateAsync(Pedido pedido);
	Task DeleteAsync(int id);
	Task UpdateStatusAsync(int pedidoId, StatusPedido novoStatus, int UsuarioId);
}
