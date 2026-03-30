using Application.Interfaces;
using Domain;
using InfraStructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application;

public class DepartamentoService : IDepartamentoService
{
	private readonly IDepartamentoRepository _repository;

	public DepartamentoService(IDepartamentoRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Departamento>> GetAllAsync()
			=> await _repository.GetAllAsync();

	public async Task<Departamento?> GetByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

	public async Task AddAsync(Departamento departamento)
	{
		await _repository.AddAsync(departamento);
		await _repository.SaveChangesAsync();
	}

	public async Task UpdateAsync(Departamento departamento)
	{
		_repository.Update(departamento);
		await _repository.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var departamento = await _repository.GetByIdAsync(id);
		if (departamento is null) return;
		_repository.Delete(departamento);
		await _repository.SaveChangesAsync();
	}
}
