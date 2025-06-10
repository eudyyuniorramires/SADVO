using Microsoft.EntityFrameworkCore;
using SADVO.Core.Domain.Entities;
using SADVO.Infrastructure.Persistence.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
          
       public DbSet<AlianzaPolitica> AlianzaPoliticas { get; set; }

       public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<CandidatoPuesto> CandidatoPuestos { get; set; }

        public DbSet<DirigentePartido> DirigentePartidos { get; set; }

        public DbSet<Eleccion> Elecciones { get; set; }

        public DbSet<PuestoElectivo> PuestoElectivos { get; set; }

        public DbSet<PartidoPolitico> PartidoPoliticos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AlianzaPoliticaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CandidatoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CandidatoPuestoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CiudadanoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DirigentePartidoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EleccionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PuestoElectivoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PartidoPoliticoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());

        }


    }
}
