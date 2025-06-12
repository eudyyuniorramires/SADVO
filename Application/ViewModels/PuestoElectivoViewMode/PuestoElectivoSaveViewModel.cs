using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.ViewModels.PuestoElectivoViewMode
{
    public class PuestoElectivoSaveViewModel
    {


        public int Id { get; set; } 
        public required string Nombre { get; set; }


        public required string Descripcion { get; set; }


        public bool EstadoActivo { get; set; }  




    }
}
