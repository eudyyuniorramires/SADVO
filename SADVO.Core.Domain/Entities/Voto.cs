using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class Voto
    {
        public required int Id { get; set; }

        public required int CiudadanoId { get; set; }
        public required Ciudadano Ciudadano { get; set; }

        public required int EleccionId { get; set; }
        public required Eleccion Eleccion { get; set; }

        public required int CandidatoPuestoId { get; set; }
        public required CandidatoPuesto CandidatoPuesto { get; set; }

        public DateTime FechaHora { get; set; }

    }
}
