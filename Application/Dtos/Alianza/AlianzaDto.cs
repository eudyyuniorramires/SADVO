using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Alianza
{
    public class AlianzaDto
    {
        public int Id { get; set; }

        public int PartidoSolicitanteId { get; set; }
        public string PartidoSolicitanteNombre { get; set; }
        public string PartidoSolicitanteSiglas { get; set; }

        public int PartidoReceptorId { get; set; }
        public string PartidoReceptorNombre { get; set; }
        public string PartidoReceptorSiglas { get; set; }

        public EstadoAlianza Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaResolucion { get; set; }
    }
}
