using Domain;

namespace InfraStructure.Repositories.Interfaces;

public interface IPedidoRepository
{
	Task<IEnumerable<Pedido>> GetAllAsync();
	Task<Pedido?> GetByIdAsync(int id);
	Task AddAsync(Pedido pedido);
	void Update(Pedido pedido);
	void Delete(Pedido pedido);
	Task SaveChangesAsync();
}