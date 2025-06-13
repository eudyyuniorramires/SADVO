using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.PuestoElectivoViewMode
{
    public class PuestoElectivoViewModelDelete
    {
        public required int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }


        public required bool EstaActivo { get; set; }
    }
}
