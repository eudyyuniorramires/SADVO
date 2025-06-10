using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class PartidoPoliticoEntityConfiguration : IEntityTypeConfiguration<PartidoPolitico>
    {
        public void Configure(EntityTypeBuilder<PartidoPolitico> builder)
        {
            builder.ToTable("PartidoPolitico");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Descripcion)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.Siglas)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(p => p.Siglas)
                   .IsUnique();

            builder.Property(p => p.LogoPath)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(p => p.EstaActivo)
                   .HasDefaultValue(true);

            // Relaciones

            builder.HasMany(p => p.Dirigentes)
                   .WithOne(d => d.PartidoPolitico)
                   .HasForeignKey(d => d.PartidoPoliticoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Candidatos)
                   .WithOne(c => c.PartidoPolitico)
                   .HasForeignKey(c => c.PartidoPoliticoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.AlianzasEnviadas)
                   .WithOne(a => a.PartidoSolicitante)
                   .HasForeignKey(a => a.PartidoSolicitanteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.AlianzasRecibidas)
                   .WithOne(a => a.PartidoReceptor)
                   .HasForeignKey(a => a.PartidoReceptorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
