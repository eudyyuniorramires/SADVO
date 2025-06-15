using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.PartidoPoliticoViewModel
{
    public class PartidoPoliticoDeleteViewModel
    {

        public required int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }

        public required string Siglas { get; set; } // único

        public  string LogoPath { get; set; }

        public bool EstaActivo { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
