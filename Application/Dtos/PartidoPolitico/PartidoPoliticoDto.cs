using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.PartidoPolitico
{
    public class PartidoPoliticoDto
    {
        public required int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public  string Siglas { get; set; } // único
        public  string LogoPath { get; set; }
        public bool EstaActivo { get; set; }


    }
}
