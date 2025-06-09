using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class PuestoElectivo
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public bool EstaActivo { get; set; }

        public ICollection<CandidatoPuesto> CandidatoPuestos { get; set; }
    }
}
