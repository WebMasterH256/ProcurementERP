using Microsoft.EntityFrameworkCore;
using Domain;

namespace InfraStructure;

public class AppDbContext : DbContext
{
	// Construtor para injeção de dependência
		public AppDbContext
			(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		// Mapeiamento para o SGBD
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Fornecedor> Fornecedores { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<ProdutoPedido> ProdutoPedidos { get; set; }
		public DbSet<Departamento> Departamentos { get; set; }

		// Método que controla as alterações no SGBD
		override
		protected void
		OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
}