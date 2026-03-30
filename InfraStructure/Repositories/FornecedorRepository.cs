using Domain;
using InfraStructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories;

public class FornecedorRepository : IFornecedorRepository
{
	private readonly AppDbContext _context;

	public FornecedorRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Fornecedor>> GetAllAsync()
		=> await _context.Fornecedores.ToListAsync();

	public async Task<Fornecedor?> GetByIdAsync(int id)
		=> await _context.Fornecedores.FindAsync(id);

	public async Task AddAsync(Fornecedor fornecedor)
		=> await _context.Fornecedores.AddAsync(fornecedor);

	public void Update(Fornecedor fornecedor)
		=> _context.Fornecedores.Update(fornecedor);

	public void Delete(Fornecedor fornecedor)
		=> _context.Fornecedores.Remove(fornecedor);

	public async Task SaveChangesAsync()
		=> await _context.SaveChangesAsync();
}