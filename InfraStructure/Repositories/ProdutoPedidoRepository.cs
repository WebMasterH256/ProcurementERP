using Domain;
using InfraStructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories;

public class ProdutoPedidoRepository : IProdutoPedidoRepository
{
	private readonly AppDbContext _context;

	public ProdutoPedidoRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<ProdutoPedido>> GetAllAsync()
		=> await _context.ProdutoPedidos.ToListAsync();

	public async Task<ProdutoPedido?> GetByIdAsync(int id)
		=> await _context.ProdutoPedidos.FindAsync(id);

	public async Task AddAsync(ProdutoPedido pedido)
		=> await _context.ProdutoPedidos.AddAsync(pedido);

	public void Update(ProdutoPedido pedido)
		=> _context.ProdutoPedidos.Update(pedido);

	public void Delete(ProdutoPedido pedido)
		=> _context.ProdutoPedidos.Remove(pedido);

	public async Task SaveChangesAsync()
		=> await _context.SaveChangesAsync();
}