using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.PuestoElectivo
{
    public class PuestoElectivoDto
    {
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required bool EstaActivo { get; set; }
    }
}
