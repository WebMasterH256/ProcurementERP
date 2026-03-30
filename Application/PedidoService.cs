using Application.Interfaces;
using Domain;
using InfraStructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application;

public class PedidoService : IPedidoService
{
	private readonly IPedidoRepository _repository;

	public PedidoService(IPedidoRepository repository)
	{
		_repository = repository;
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
}
