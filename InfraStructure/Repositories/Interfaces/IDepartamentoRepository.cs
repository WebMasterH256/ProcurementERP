using Domain;

namespace InfraStructure.Repositories.Interfaces;

public interface IDepartamentoRepository
{
	Task<IEnumerable<Departamento>> GetAllAsync();
	Task<Departamento?> GetByIdAsync(int id);
	Task AddAsync(Departamento departamento);
	void Update(Departamento departamento);
	void Delete(Departamento departamento);
	Task SaveChangesAsync();
}