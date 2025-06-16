using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.UsuarioViewModel
{
    public class UsuarioSaveViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public required string Contrasena { get; set; }

        [Required(ErrorMessage = "Debe repetir la contraseña")]
        [DataType(DataType.Password)]
        [Compare(nameof(Contrasena), ErrorMessage = "Las contraseñas no coinciden")]
        public required string RepeatContrasena { get; set; }

        public bool EstaActivo { get; set; }

        [Required(ErrorMessage ="El rol es obligatorio ")]
        public required string Rol { get; set; } // Enum: Administrador, Dirigente
    }
}
