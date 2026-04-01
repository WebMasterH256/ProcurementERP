using Application.Interfaces;
using Domain;
using InfraStructure.Repositories.Interfaces;

namespace Application;

public class UsuarioService : IUsuarioService
{
	private readonly IUsuarioRepository _repository;

	public UsuarioService(IUsuarioRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Usuario>> GetAllAsync()
			=> await _repository.GetAllAsync();

	public async Task<Usuario?> GetByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

	public async Task AddAsync(Usuario usuario)
	{
		await _repository.AddAsync(usuario);
		await _repository.SaveChangesAsync();
	}

	public async Task UpdateAsync(Usuario usuario)
	{
		_repository.Update(usuario);
		await _repository.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var usuario = await _repository.GetByIdAsync(id);
		if (usuario is null) return;
		_repository.Delete(usuario);
		await _repository.SaveChangesAsync();
	}

	public async Task<Usuario?> GetByEmailAsync(string email)
		=> await _repository.GetByEmailAsync(email);
}
