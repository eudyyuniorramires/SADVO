using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class CandidatoEntityConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {

            builder.ToTable("Candidatos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(c  => c.Apellido)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(c => c.FotoPath)
                .IsRequired()
                .HasMaxLength(255);


            builder.Property(c => c.EstaActivo)
                .IsRequired();

            builder.HasOne( c => c.PartidoPolitico)
                .WithMany(p => p.Candidatos)
                .HasForeignKey(c => c.PartidoPoliticoId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete to prevent cascading deletes, as a candidate should not be deleted if the party is deleted.



        }
    }
}
