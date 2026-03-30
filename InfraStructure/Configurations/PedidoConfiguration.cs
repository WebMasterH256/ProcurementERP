using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
	public void
		Configure(EntityTypeBuilder<Pedido> builder)
	{
		builder.ToTable("Pedido");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Valor)
			.IsRequired();

		builder.Property(p => p.Criacao)
			.IsRequired();

		builder.Property(p => p.Status)
			.IsRequired();

		builder.HasMany(p => p.Produtos)
			.WithOne(pp => pp.Pedido)
			.HasForeignKey(pp => pp.PedidoId)
			.OnDelete(DeleteBehavior.Restrict);


	}
}