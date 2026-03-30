using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
	public void Configure(EntityTypeBuilder<Departamento> builder)
	{
		builder.ToTable("Departamento");

		builder.HasKey(d => d.Id);

		builder.Property(d => d.Nome)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(d => d.Orcamento)
			.IsRequired()
			.HasPrecision(18, 2);

		builder.HasMany(d => d.Pedidos)
			.WithOne(u => u.Departamento)
			.HasForeignKey(u => u.DepartamentoId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(d => d.Usuarios)
			.WithOne(u => u.Departamento)
			.HasForeignKey(u => u.DepartamentoId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}