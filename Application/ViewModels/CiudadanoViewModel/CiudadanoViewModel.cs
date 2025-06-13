using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.Ciudadano
{
    public class CiudadanoViewModel
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El campo email es obligatorio.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "El campo documento de identidad es obligatorio.")]
        public required string DocumentoIdentidad { get; set; }
        public bool EstaActivo { get; set; }
    }
}
