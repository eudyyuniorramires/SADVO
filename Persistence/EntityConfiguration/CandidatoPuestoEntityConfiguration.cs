using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class CandidatoPuestoEntityConfiguration : IEntityTypeConfiguration<CandidatoPuesto>
    {
        public void Configure(EntityTypeBuilder<CandidatoPuesto> builder)
        {
            builder.ToTable("CandidatoPuesto");

            builder.HasKey(cp => cp.Id);

            // Relación con Candidato
            builder.HasOne(cp => cp.Candidato)
                   .WithMany(c => c.CandidatoPuestos)
                   .HasForeignKey(cp => cp.CandidatoId)
                   .OnDelete(DeleteBehavior.Cascade); // Se eliminan los registros intermedios si se borra el candidato

            // Relación con PuestoElectivo
            builder.HasOne(cp => cp.PuestoElectivo)
                   .WithMany(pe => pe.CandidatoPuestos) // Debes definir esta colección en PuestoElectivo
                   .HasForeignKey(cp => cp.PuestoElectivoId)
                   .OnDelete(DeleteBehavior.Restrict); // No se borra el puesto si se elimina el enlace
        }
    }
}
