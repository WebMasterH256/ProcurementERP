using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace InfraStructure.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
	public void
		Configure(EntityTypeBuilder<Usuario> builder)
	{
		builder.ToTable("Usuario");

		builder.HasKey(u => u.Id);

		builder.Property(u => u.Nome)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(u => u.Email)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(u => u.Senha)
			.IsRequired()
			.HasMaxLength(64);

		builder.Property(u => u.Cargo)
			.IsRequired();

		builder.HasMany(u => u.Pedidos)
			.WithOne(p => p.Usuario)
			.HasForeignKey(p => p.UsuarioId)
			.OnDelete(DeleteBehavior.Restrict);

	}
}