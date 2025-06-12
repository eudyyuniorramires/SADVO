using SADVO.Core.Application.Dtos.PuestoElectivo;
using SADVO.Core.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface IPuestoElectivo
    {
        Task<bool> AddAsync(PuestoElectivoDto dto);
        Task<bool> UpdateAsync(PuestoElectivoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<PuestoElectivoDto>> GetAll();
        Task<List<PuestoElectivoDto>> GetAllWithInclude();
        Task<PuestoElectivoDto?> GetById(int id);
    }
}
