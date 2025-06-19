using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Interfaces
{
    public interface IAsignacionDirigentePoliticoRepository : IGenericRepository<DirigentePartido>
    {

        Task<bool> ExistsByUsuarioId(int usuarioId);

        Task<List<DirigentePartido>> GetAllWithIncludesAsync();


        Task<DirigentePartido?> GetByUsuarioIdAsync(int usuarioId);


    }
}
