using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
	public void
		Configure(EntityTypeBuilder<Fornecedor> builder)
	{
		builder.ToTable("Fornecedor");

		builder.HasKey(f => f.Id);

		builder.Property(f => f.Nome)
			.HasMaxLength(100).
			IsRequired();

		builder.Property(f => f.Telefone)
			.IsRequired();

		builder.Property(f => f.Email)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(f => f.Cnpj)
			.HasMaxLength(18)
			.IsRequired();

		builder.HasMany(f => f.Produtos)
			.WithOne(p => p.Fornecedor)
			.HasForeignKey(p => p.FornecedorId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}