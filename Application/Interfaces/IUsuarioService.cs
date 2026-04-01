using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;

public interface IUsuarioService
{
	Task<IEnumerable<Usuario>> GetAllAsync();
	Task<Usuario?> GetByIdAsync(int id);
	Task AddAsync(Usuario usuario);
	Task UpdateAsync(Usuario usuario);
	Task DeleteAsync(int id);
	Task<Usuario?> GetByEmailAsync(string email);
}
