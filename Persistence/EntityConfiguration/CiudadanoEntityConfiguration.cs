using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class CiudadanoEntityConfiguration : IEntityTypeConfiguration<Ciudadano>
    {
        public void Configure(EntityTypeBuilder<Ciudadano> builder)
        {
            builder.ToTable("Ciudadano");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Apellido)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.DocumentoIdentidad)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(c => c.EstaActivo)
                   .IsRequired();

            // Relación uno a muchos con Voto
            builder.HasMany(c => c.Votos)
                   .WithOne(v => v.Ciudadano)
                   .HasForeignKey(v => v.CiudadanoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
