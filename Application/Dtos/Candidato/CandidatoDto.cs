using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Candidato
{
    public class CandidatoDto
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string FotoPath { get; set; }
        public bool EstaActivo { get; set; }

        public int PartidoPoliticoId { get; set; }
        public object NombrePartido { get; internal set; }
    }
}
