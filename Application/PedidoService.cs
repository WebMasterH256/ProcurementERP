using Application.Interfaces;
using Domain;
using InfraStructure;
using InfraStructure.Repositories.Interfaces;

namespace Application;

public class PedidoService : IPedidoService
{
	private readonly IPedidoRepository _repository;
	private readonly AppDbContext _context;

	public PedidoService(IPedidoRepository repository, AppDbContext context)
	{
		_repository = repository;
		_context = context;
	}

	public async Task<IEnumerable<Pedido>> GetAllAsync()
			=> await _repository.GetAllAsync();

	public async Task<Pedido?> GetByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

	public async Task AddAsync(Pedido pedido)
	{
		await _repository.AddAsync(pedido);
		await _repository.SaveChangesAsync();
	}

	public async Task UpdateAsync(Pedido pedido)
	{
		_repository.Update(pedido);
		await _repository.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var pedido = await _repository.GetByIdAsync(id);
		if (pedido is null) return;
		_repository.Delete(pedido);
		await _repository.SaveChangesAsync();
	}

	public async Task UpdateStatusAsync(int pedidoId, StatusPedido novoStatus, int usuarioId)
	{
		var pedido = await _repository.GetByIdAsync(pedidoId);
		if (pedido is null) return;

		var audit = new AuditLog
		{
			PedidoId = pedidoId,
			StatusAnterior = pedido.Status.ToString(),
			StatusNovo = novoStatus.ToString(),
			UsuarioId = usuarioId,
			Data = DateTime.UtcNow
		};

		pedido.Status = novoStatus;
		_repository.Update(pedido);
		await _context.AuditLogs.AddAsync(audit);
		await _repository.SaveChangesAsync();
	}
}
