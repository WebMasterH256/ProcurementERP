using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class ProdutoPedidoConfiguration : IEntityTypeConfiguration<ProdutoPedido>
{
	public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
	{
		builder.ToTable("ProdutoPedido");

		builder.HasKey(pp => pp.Id);

		builder.Property(pp => pp.Quantidade)
			.IsRequired();

		builder.Property(pp => pp.PrecoUnitario)
			.HasColumnType("decimal(18,2)")
			.IsRequired();
	}
}