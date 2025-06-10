using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class EleccionEntityConfiguration : IEntityTypeConfiguration<Eleccion>
    {
        public void Configure(EntityTypeBuilder<Eleccion> builder)
        {
            builder.ToTable("Eleccion");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(e => e.Fecha)
                   .IsRequired();

            builder.Property(e => e.Estado)
                   .IsRequired();

            // Relación uno-a-muchos con Voto
            builder.HasMany(e => e.Votos)
                   .WithOne(v => v.Eleccion)
                   .HasForeignKey(v => v.EleccionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
