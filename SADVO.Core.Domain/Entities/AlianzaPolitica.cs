using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class AlianzaPolitica
    {
        public required int Id { get; set; }

        public required int PartidoSolicitanteId { get; set; }
        public required PartidoPolitico PartidoSolicitante { get; set; }

        public required int PartidoReceptorId { get; set; }
        public required PartidoPolitico PartidoReceptor { get; set; }

        public required EstadoAlianza Estado { get; set; } // Enum: EnEspera, Aceptada, Rechazada
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaResolucion { get; set; }
    }
}
