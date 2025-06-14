using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface IPartidoPoliticoService
    {
        Task<bool> AddAsync(PartidoPoliticoDto dto);
        Task<bool> UpdateAsync(PartidoPoliticoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<PartidoPoliticoDto>> GetAll();
        Task<List<PartidoPoliticoDto>> GetAllWithInclude();
        Task<PartidoPoliticoDto?> GetById(int id);
    }
}
