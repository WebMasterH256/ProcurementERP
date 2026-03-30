using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IProdutoPedidoService
{
	Task<IEnumerable<ProdutoPedido>> GetAllAsync();
	Task<ProdutoPedido?> GetByIdAsync(int id);
	Task AddAsync(ProdutoPedido pedido);
	Task UpdateAsync(ProdutoPedido pedido);
	Task DeleteAsync(int id);
}
