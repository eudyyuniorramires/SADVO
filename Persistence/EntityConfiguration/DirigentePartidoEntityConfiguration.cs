using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SADVO.Core.Domain.Entities;

namespace SADVO.Infrastructure.Persistence.EntityConfiguration
{
    public class DirigentePartidoEntityConfiguration : IEntityTypeConfiguration<DirigentePartido>
    {
        public void Configure(EntityTypeBuilder<DirigentePartido> builder)
        {
            builder.ToTable("DirigentePartido");

            builder.HasKey(dp => dp.Id);

            // Relación con Usuario
            builder.HasOne(dp => dp.Usuario)
                   .WithMany() // Puedes cambiar a .WithMany(u => u.Dirigencias) si defines esa colección en Usuario
                   .HasForeignKey(dp => dp.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con PartidoPolitico
            builder.HasOne(dp => dp.PartidoPolitico)
                   .WithMany() // Igual: puedes usar .WithMany(p => p.Dirigentes) si defines esa colección en PartidoPolitico
                   .HasForeignKey(dp => dp.PartidoPoliticoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
