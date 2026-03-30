using Domain;

namespace InfraStructure.Repositories.Interfaces;

public interface IFornecedorRepository
{
	Task<IEnumerable<Fornecedor>> GetAllAsync();
	Task<Fornecedor?> GetByIdAsync(int id);
	Task AddAsync(Fornecedor fornecedor);
	void Update(Fornecedor fornecedor);
	void Delete(Fornecedor fornecedor);
	Task SaveChangesAsync();
}