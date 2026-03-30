using Domain;

namespace InfraStructure.Repositories.Interfaces;

public interface IProdutoPedidoRepository
{
	Task<IEnumerable<ProdutoPedido>> GetAllAsync();
	Task<ProdutoPedido?> GetByIdAsync(int id);
	Task AddAsync(ProdutoPedido pedido);
	void Update(ProdutoPedido pedido);
	void Delete(ProdutoPedido pedido);
	Task SaveChangesAsync();
}