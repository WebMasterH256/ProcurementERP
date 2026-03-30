using Application.Interfaces;
using Domain;
using InfraStructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application;

public class FornecedorService : IFornecedorService
{
	private readonly IFornecedorRepository _repository;

	public FornecedorService(IFornecedorRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Fornecedor>> GetAllAsync()
			=> await _repository.GetAllAsync();

	public async Task<Fornecedor?> GetByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

	public async Task AddAsync(Fornecedor fornecedor)
	{
		await _repository.AddAsync(fornecedor);
		await _repository.SaveChangesAsync();
	}

	public async Task UpdateAsync(Fornecedor fornecedor)
	{
		_repository.Update(fornecedor);
		await _repository.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var produto = await _repository.GetByIdAsync(id);
		if (produto is null) return;
		_repository.Delete(produto);
		await _repository.SaveChangesAsync();
	}
}
