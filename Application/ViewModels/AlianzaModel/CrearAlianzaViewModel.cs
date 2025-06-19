using SADVO.Core.Application.Dtos.PartidoPolitico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.AlianzaModel
{
    public class CrearAlianzaViewModel
    {
        public List<PartidoPoliticoDto> PartidosDisponibles { get; set; } = new();

    }
}
