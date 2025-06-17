using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.DirigentePoliticoViewModel
{
    public class DirigentePoliticoDeleteViewModel
    {
        public required int Id { get; set; }
        public required int UsuarioId { get; set; }

        public required int PartidoPoliticoId { get; set; }

      
    }
}
