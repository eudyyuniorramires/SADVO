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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        public bool EstaActivo { get; set; }

        public RolUsuario Rol { get; set; } // Enum: Administrador, Dirigente

        public DirigentePartido DirigentePartido { get; set; } // Relación 1-1
    }
}
