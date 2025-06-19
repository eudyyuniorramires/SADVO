using SADVO.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Domain.Interfaces
{

    public interface IAlianzaPoliticaRepository
    {
        Task<List<AlianzaPolitica>> GetSolicitudesRecibidasAsync(int partidoReceptorId);
        Task<List<AlianzaPolitica>> GetSolicitudesEnviadasAsync(int partidoSolicitanteId);
        Task<List<AlianzaPolitica>> GetAlianzasAceptadasAsync(int partidoId);
        Task<AlianzaPolitica?> GetByIdAsync(int id);
        Task<bool> ExisteSolicitudActivaEntreAsync(int partidoAId, int partidoBId);
        Task AddAsync(AlianzaPolitica alianza);
        Task DeleteAsync(AlianzaPolitica alianza);
        Task SaveChangesAsync();
    }

}
