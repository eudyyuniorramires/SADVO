using SADVO.Core.Application.Dtos.Ciudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface ICiudadano
    {
        Task<bool> AddAsync(CiudadanoDto dto);
        Task<bool> UpdateAsync(CiudadanoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<CiudadanoDto>> GetAll();
        Task<List<CiudadanoDto>> GetAllWithInclude();
        Task<CiudadanoDto?> GetById(int id);
    }
}
