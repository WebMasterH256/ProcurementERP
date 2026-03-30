using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IDepartamentoService
{
	Task<IEnumerable<Departamento>> GetAllAsync();
	Task<Departamento?> GetByIdAsync(int id);
	Task AddAsync(Departamento departamento);
	Task UpdateAsync(Departamento departamento);
	Task DeleteAsync(int id);
}
