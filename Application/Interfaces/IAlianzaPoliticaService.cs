using SADVO.Core.Application.Dtos.Alianza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Interfaces
{
    public interface IAlianzaPoliticaService
    {
        Task<List<AlianzaDto>> GetSolicitudesRecibidasAsync(int partidoId);
        Task<List<AlianzaDto>> GetSolicitudesEnviadasAsync(int partidoId);
        Task<List<AlianzaDto>> GetAlianzasVigentesAsync(int partidoId);
        Task<bool> AceptarSolicitudAsync(int id);
        Task<bool> RechazarSolicitudAsync(int id);
        Task<bool> EliminarSolicitudAsync(int id);
        Task<bool> CrearSolicitudAsync(int solicitanteId, int receptorId);
        Task<AlianzaDto?> GetByIdDtoAsync(int id);
    }

}
