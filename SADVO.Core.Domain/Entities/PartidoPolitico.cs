using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class PartidoPolitico
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required string Siglas { get; set; } // único
        public required string LogoPath { get; set; }
        public bool EstaActivo { get; set; }

        public ICollection<DirigentePartido> Dirigentes { get; set; }
        public ICollection<Candidato> Candidatos { get; set; }
        public ICollection<AlianzaPolitica> AlianzasEnviadas { get; set; }
        public ICollection<AlianzaPolitica> AlianzasRecibidas { get; set; }
    }
}
