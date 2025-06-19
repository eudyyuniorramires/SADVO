using SADVO.Core.Application.Dtos.Ciudadano;
using SADVO.Core.Application.Dtos.DirigentePolitico;
using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface IDirigentePartidoService 
    {
        Task<bool> AddAsync(DirigentePartidoDto dto);
        Task<bool> UpdateAsync(DirigentePartidoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<DirigentePartidoDto>> GetAll();
        Task<List<DirigentePartidoDto>> GetAllWithInclude();
        Task<DirigentePartidoDto?> GetById(int id);
        Task<bool> ExistsByUsuarioId(int usuarioId);
        Task<DirigentePartidoDto?> GetByUsuarioIdAsync(int usuarioId);






    }
}
