using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IProdutoService
{
	Task<IEnumerable<Produto>> GetAllAsync();
	Task<Produto?> GetByIdAsync(int id);
	Task AddAsync(Produto produto);
	Task UpdateAsync(Produto produto);
	Task DeleteAsync(int id);
}
