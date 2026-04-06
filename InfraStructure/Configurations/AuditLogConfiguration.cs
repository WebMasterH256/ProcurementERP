using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
	public void Configure(EntityTypeBuilder<AuditLog> builder)
	{
		builder.ToTable("AuditLog");
		builder.HasKey(a => a.Id);
		builder.Property(a => a.StatusAnterior)
			.IsRequired()
			.HasMaxLength(255);
		builder.Property(a => a.StatusNovo)
			.IsRequired()
			.HasMaxLength(255);
		builder.Property(a => a.Data)
			.IsRequired();
		builder.Property(a => a.PedidoId)
			.IsRequired();
		builder.Property(a => a.UsuarioId)
			.IsRequired();
	}
}
