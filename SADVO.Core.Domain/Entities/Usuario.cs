using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public  required string Email { get; set; }
        public  required string ContrasenaHash { get; set; }
        public bool EstaActivo { get; set; }

        public RolUsuario Rol { get; set; } 

        public DirigentePartido ?DirigentePartido { get; set; }

        
    }
}
