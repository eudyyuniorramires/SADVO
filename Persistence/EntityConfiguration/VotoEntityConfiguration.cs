using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class VotoEntityConfiguration : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.ToTable("Voto");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.FechaHora)
                   .IsRequired();

            // Relaciones

            builder.HasOne(v => v.Ciudadano)
                   .WithMany(c => c.Votos)
                   .HasForeignKey(v => v.CiudadanoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Eleccion)
                   .WithMany(e => e.Votos)
                   .HasForeignKey(v => v.EleccionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.CandidatoPuesto)
                   .WithMany(cp => cp.Votos)
                   .HasForeignKey(v => v.CandidatoPuestoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
