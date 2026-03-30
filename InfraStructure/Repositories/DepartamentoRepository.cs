using Domain;
using InfraStructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories;

public class DepartamentoRepository : IDepartamentoRepository
{
	private readonly AppDbContext _context;

	public DepartamentoRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Departamento>> GetAllAsync()
		=> await _context.Departamentos.ToListAsync();

	public async Task<Departamento?> GetByIdAsync(int id)
		=> await _context.Departamentos.FindAsync(id);

	public async Task AddAsync(Departamento departamento)
		=> await _context.Departamentos.AddAsync(departamento);

	public void Update(Departamento departamento)
		=> _context.Departamentos.Update(departamento);

	public void Delete(Departamento departamento)
		=> _context.Departamentos.Remove(departamento);

	public async Task SaveChangesAsync()
		=> await _context.SaveChangesAsync();
}