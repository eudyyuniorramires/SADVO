using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Elecciones
{

    
        namespace SADVO.Core.Application.Dtos.Eleccion
    {
        public class EleccionDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public EstadoEleccion Estado { get; set; }
            public int CantidadPartidos { get; set; }
            public int CantidadPuestos { get; set; }
        }
    }

}

