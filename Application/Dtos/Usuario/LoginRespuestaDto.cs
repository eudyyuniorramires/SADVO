using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Dtos.Usuario
{
    public class LoginResponseDto
    {
        public bool Exito { get; set; }  // true si el login fue exitoso
        public string? Mensaje { get; set; } // mensaje de error si Exito == false
        public UsuarioDto? Usuario { get; set; } // solo se llena si Exito == true
    }

}
