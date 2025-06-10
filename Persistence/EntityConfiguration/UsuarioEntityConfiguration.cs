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
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Apellido)
                 .IsRequired()
                  .HasMaxLength(100);


            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.ContrasenaHash)
                .IsRequired()
                 .HasMaxLength(200);    


            builder.Property(u => u.EstaActivo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Rol)
                .IsRequired()
                .HasMaxLength(50);

            // Relación uno a uno con DirigentePartido

            builder.HasOne(u => u.DirigentePartido)
                .WithOne(dp => dp.Usuario)
                .HasForeignKey<DirigentePartido>(dp => dp.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
