using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IFornecedorService
{
	Task<IEnumerable<Fornecedor>> GetAllAsync();
	Task<Fornecedor?> GetByIdAsync(int id);
	Task AddAsync(Fornecedor fornecedor);
	Task UpdateAsync(Fornecedor fornecedor);
	Task DeleteAsync(int id);
}
