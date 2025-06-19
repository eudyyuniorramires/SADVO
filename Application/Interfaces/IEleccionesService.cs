using SADVO.Core.Application.Dtos.Elecciones;
using SADVO.Core.Application.Dtos.Elecciones.SADVO.Core.Application.Dtos.Eleccion;
using SADVO.Core.Application.Dtos.PuestoElectivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface IEleccionesService 
    {
        Task<(bool PuedeCrear, List<string> Errores)> ValidarCreacionAsync();
        Task<bool> CrearAsync(CrearEleccionDto dto);
        Task<List<EleccionDto>> GetAllAsync();
        Task<bool> FinalizarAsync(int id);
    }
}
