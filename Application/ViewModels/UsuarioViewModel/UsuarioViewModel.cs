using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.UsuarioViewModel
{
    public class UsuarioViewModel
    {
        public required int Id { get; set; } 

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Compare(nameof(RepeatContrasena), ErrorMessage = "Las contraseñas no coinciden")] 
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public required string Contrasena { get; set; }


        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
        public required string RepeatContrasena { get; set; }

        public bool EstaActivo { get; set; }

        [Required(ErrorMessage ="Ingrese un Rol")]
        public required string Rol { get; set; } // Enum: Administrador, Dirigente
        public int PartidoPoliticoId { get; set; }
    }
}
