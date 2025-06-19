using SADVO.Core.Application.Dtos.Alianza;
using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.AlianzaModel
{
    public class AlianzaListadoViewModel
    {
       
        public List<AlianzaDto> SolicitudesRecibidas { get; set; }
        public List<AlianzaDto> SolicitudesEnviadas { get; set; }
        public List<AlianzaDto> AlianzasVigentes { get; set; }
    }
}
