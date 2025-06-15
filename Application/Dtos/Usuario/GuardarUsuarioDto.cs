using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Usuario
{
    public class GuardarUsuarioDto
    {
        public required int Id { get; set; } 
        public required string Nombre { get; set; }

        public required string Apellido { get; set; }

        public required string Email { get; set; }

        public required string ContrasenaHash { get; set; }

        public required string ConfirmanPassword { get; set; }

        public required string Rol { get; set; } // Ejemplo: "Admin", "User"

        public bool EstaActivo { get; set; } = true;

        public string? ErrorMessage { get; set; }
    }
}
