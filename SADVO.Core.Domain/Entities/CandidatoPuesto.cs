using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class CandidatoPuesto
    {
        public required int Id { get; set; }

        public required int CandidatoId { get; set; }
        public required Candidato Candidato { get; set; }
        public required int PuestoElectivoId { get; set; }
        public required PuestoElectivo PuestoElectivo { get; set; }
        public ICollection<Voto>? Votos { get; set; }

    }
}
