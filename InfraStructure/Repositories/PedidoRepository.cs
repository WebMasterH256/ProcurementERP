using Domain;
using InfraStructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
	private readonly AppDbContext _context;

	public PedidoRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Pedido>> GetAllAsync()
		=> await _context.Pedidos.ToListAsync();

	public async Task<Pedido?> GetByIdAsync(int id)
		=> await _context.Pedidos.FindAsync(id);

	public async Task AddAsync(Pedido pedido)
		=> await _context.Pedidos.AddAsync(pedido);

	public void Update(Pedido pedido)
		=> _context.Pedidos.Update(pedido);

	public void Delete(Pedido pedido)
		=> _context.Pedidos.Remove(pedido);

	public async Task SaveChangesAsync()
		=> await _context.SaveChangesAsync();
}