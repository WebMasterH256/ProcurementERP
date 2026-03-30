using Domain;

namespace InfraStructure.Repositories.Interfaces;

public interface IUsuarioRepository
{
	Task<IEnumerable<Usuario>> GetAllAsync();
	Task<Usuario?> GetByIdAsync(int id);
	Task AddAsync(Usuario usuario);
	void Update(Usuario usuario);
	void Delete(Usuario usuario);
	Task SaveChangesAsync();
}