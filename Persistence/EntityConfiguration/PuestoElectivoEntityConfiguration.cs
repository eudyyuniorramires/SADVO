using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class PuestoElectivoEntityConfiguration : IEntityTypeConfiguration<PuestoElectivo>
    {
        public void Configure(EntityTypeBuilder<PuestoElectivo> builder)
        {
            builder.ToTable("PuestoElectivo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Descripcion)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.EstaActivo)
                   .HasDefaultValue(true);

            // Relación con CandidatoPuesto (uno a muchos)
            builder.HasMany(p => p.CandidatoPuestos)
                   .WithOne(cp => cp.PuestoElectivo)
                   .HasForeignKey(cp => cp.PuestoElectivoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
