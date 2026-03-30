using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
	public void
		Configure(EntityTypeBuilder<Produto> builder)
	{
		builder.ToTable("Produto");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Nome)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(p => p.Descricao)
			.HasMaxLength(1023);

		builder.Property(p => p.PrecoAtual)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(p => p.Quantidade)
			.IsRequired();

		builder.Property(p => p.FornecedorId)
			.IsRequired();

		builder.HasMany(p => p.ProdutosPedidos)
			.WithOne(p => p.Produto)
			.HasForeignKey(p => p.ProdutoId)
			.OnDelete(DeleteBehavior.Restrict);

	}

}