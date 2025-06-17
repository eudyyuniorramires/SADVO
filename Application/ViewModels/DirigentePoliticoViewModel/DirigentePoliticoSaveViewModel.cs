using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.DirigentePoliticoViewModel
{
    public class DirigentePoliticoSaveViewModel
    {
        public required int Id { get; set; }

        [Required(ErrorMessage ="Debe seleccionar un USUARIO")]
        public required int UsuarioId { get; set; }

        [Required(ErrorMessage ="Debe seleccionar un Partido Politico")]
        public required int PartidoPoliticoId { get; set; }

        public string? NombreUsuario { get; set; }
        public string? NombrePartido { get; set; }



    }
}
