using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;


namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class AlianzaPoliticaEntityConfiguration : IEntityTypeConfiguration<AlianzaPolitica>
    {
        public void Configure(EntityTypeBuilder<AlianzaPolitica> builder)
        {
           
            builder.ToTable("AlianzaPolitica");

            builder.HasKey(a => a.Id);


            builder.HasOne(a => a.PartidoSolicitante)
                .WithMany()
                .HasForeignKey(a => a.PartidoSolicitanteId) 
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(a => a.PartidoReceptor)
                .WithMany()
                .HasForeignKey(a => a.PartidoReceptorId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Property(a => a.Estado)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(a => a.FechaSolicitud)
                .IsRequired();

            builder.Property(a => a.FechaResolucion)
                .IsRequired(false); // Puede ser nulo si la alianza aún no ha sido resuelta




        }
    }
}
