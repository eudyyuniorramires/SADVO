using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Ciudadano
{
    public class CiudadanoDto
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Email { get; set; }
        public  string DocumentoIdentidad { get; set; }
        public bool EstaActivo { get; set; } 
    }
}
