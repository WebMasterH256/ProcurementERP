using Application.Interfaces;
using Domain;
using InfraStructure.Repositories.Interfaces;

namespace Application;

public class ProdutoService : IProdutoService
{
	private readonly IProdutoRepository _repository;

	public ProdutoService(IProdutoRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Produto>> GetAllAsync()
			=> await _repository.GetAllAsync();

	public async Task<Produto?> GetByIdAsync(int id)
			=> await _repository.GetByIdAsync(id);

	public async Task AddAsync(Produto produto)
	{
		await _repository.AddAsync(produto);
		await _repository.SaveChangesAsync();
	}

	public async Task UpdateAsync(Produto produto)
	{
		_repository.Update(produto);
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
