using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class AlianzaPolitica
    {
        public  int Id { get; set; }

        public  int PartidoSolicitanteId { get; set; }
        public  PartidoPolitico PartidoSolicitante { get; set; }

        public  int PartidoReceptorId { get; set; }
        public  PartidoPolitico PartidoReceptor { get; set; }

        public  EstadoAlianza Estado { get; set; } // Enum: EnEspera, Aceptada, Rechazada
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaResolucion { get; set; }
    }
}
