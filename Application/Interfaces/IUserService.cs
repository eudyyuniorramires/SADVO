using SADVO.Core.Application.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> AddAsync(GuardarUsuarioDto dto);
        Task<bool> UpdateAsync(GuardarUsuarioDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<UsuarioDto>> GetAll();
        Task<List<UsuarioDto>> GetAllWithInclude();
        Task<UsuarioDto?> GetById(int id);

        Task<UsuarioDto?> LoginAsync(LoginDto dto);
    }
}
