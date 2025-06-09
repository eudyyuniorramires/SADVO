using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class Eleccion
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required DateTime Fecha { get; set; }
        public required EstadoEleccion Estado { get; set; } // Enum: EnProceso, Finalizada

        public required ICollection<Voto> Votos { get; set; }
    }
}
