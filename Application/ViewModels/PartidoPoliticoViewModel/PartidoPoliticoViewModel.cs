using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.PartidoPoliticoViewModel
{
    public class PartidoPoliticoViewModel
    {
        [Required(ErrorMessage = "El Id es requerido")]
        public required int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public required string Descripcion { get; set; }
        [Required(ErrorMessage = "Las siglas son requeridas")]
        public required string Siglas { get; set; } // único
        [Required(ErrorMessage = "La ruta del logo es requerida")]
        public required string LogoPath { get; set; }
        [Required(ErrorMessage = "El estado de actividad es requerido")]
        public bool EstaActivo { get; set; }
    }
}
