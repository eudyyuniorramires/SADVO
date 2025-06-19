using SADVO.Core.Application.Dtos;
using SADVO.Core.Application.Dtos.Alianza;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using System.ComponentModel.Design;

public class AlianzaPoliticaService : IAlianzaPoliticaService
{
    private readonly IAlianzaPoliticaRepository _repository;
    private readonly IEleccionesService _eleccionService;

    public AlianzaPoliticaService(IAlianzaPoliticaRepository repository, IEleccionesService eleccionService)
    {
        _repository = repository;
        _eleccionService = eleccionService;
    }

    public async Task<List<AlianzaDto>> GetSolicitudesRecibidasAsync(int partidoId)
    {
        var entities = await _repository.GetSolicitudesRecibidasAsync(partidoId);

        return entities.Select(a => new AlianzaDto
        {
            Id = a.Id,
            PartidoSolicitanteId = a.PartidoSolicitanteId,
            PartidoSolicitanteNombre = a.PartidoSolicitante.Nombre,
            PartidoSolicitanteSiglas = a.PartidoSolicitante.Siglas,
            PartidoReceptorId = a.PartidoReceptorId,
            Estado = a.Estado,
            FechaSolicitud = a.FechaSolicitud,
            FechaResolucion = a.FechaResolucion
        }).ToList();
    }

    public async Task<List<AlianzaDto>> GetSolicitudesEnviadasAsync(int partidoId)
    {
        var entities = await _repository.GetSolicitudesEnviadasAsync(partidoId);

        return entities.Select(a => new AlianzaDto
        {
            Id = a.Id,
            PartidoReceptorId = a.PartidoReceptorId,
            PartidoReceptorNombre = a.PartidoReceptor.Nombre,
            PartidoReceptorSiglas = a.PartidoReceptor.Siglas,
            Estado = a.Estado,
            FechaSolicitud = a.FechaSolicitud,
            FechaResolucion = a.FechaResolucion
        }).ToList();
    }

    public async Task<List<AlianzaDto>> GetAlianzasVigentesAsync(int partidoId)
    {
        var entities = await _repository.GetAlianzasAceptadasAsync(partidoId);

        return entities.Select(a => new AlianzaDto
        {
            Id = a.Id,
            PartidoSolicitanteId = a.PartidoSolicitanteId,
            PartidoSolicitanteNombre = a.PartidoSolicitante.Nombre,
            PartidoSolicitanteSiglas = a.PartidoSolicitante.Siglas,
            PartidoReceptorId = a.PartidoReceptorId,
            PartidoReceptorNombre = a.PartidoReceptor.Nombre,
            PartidoReceptorSiglas = a.PartidoReceptor.Siglas,
            Estado = a.Estado,
            FechaSolicitud = a.FechaSolicitud,
            FechaResolucion = a.FechaResolucion
        }).ToList();
    }

    public async Task<AlianzaDto?> GetByIdDtoAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        return new AlianzaDto
        {
            Id = entity.Id,
            PartidoSolicitanteId = entity.PartidoSolicitanteId,
            PartidoSolicitanteNombre = entity.PartidoSolicitante.Nombre,
            PartidoSolicitanteSiglas = entity.PartidoSolicitante.Siglas,
            PartidoReceptorId = entity.PartidoReceptorId,
            PartidoReceptorNombre = entity.PartidoReceptor.Nombre,
            PartidoReceptorSiglas = entity.PartidoReceptor.Siglas,
            Estado = entity.Estado,
            FechaSolicitud = entity.FechaSolicitud,
            FechaResolucion = entity.FechaResolucion
        };
    }

    public async Task<bool> AceptarSolicitudAsync(int id)
    {
        if (await _eleccionService.ExisteEleccionActivaAsync())
            return false;

        var entity = await _repository.GetByIdAsync(id);
        if (entity == null || entity.Estado != EstadoAlianza.EnEspera)
            return false;

        entity.Estado = EstadoAlianza.Aceptada;
        entity.FechaResolucion = DateTime.Now;

        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RechazarSolicitudAsync(int id)
    {
        if (await _eleccionService.ExisteEleccionActivaAsync())
            return false;

        var entity = await _repository.GetByIdAsync(id);
        if (entity == null || entity.Estado != EstadoAlianza.EnEspera)
            return false;

        entity.Estado = EstadoAlianza.Rechazada;
        entity.FechaResolucion = DateTime.Now;

        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarSolicitudAsync(int id)
    {
        if (await _eleccionService.ExisteEleccionActivaAsync())
            return false;

        var entity = await _repository.GetByIdAsync(id);
        if (entity == null || entity.Estado != EstadoAlianza.EnEspera)
            return false;

        await _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CrearSolicitudAsync(int solicitanteId, int receptorId)
    {
        if (await _eleccionService.ExisteEleccionActivaAsync())
            return false;

        if (await _repository.ExisteSolicitudActivaEntreAsync(solicitanteId, receptorId))
            return false;

        var nueva = new AlianzaPolitica
        {
            Id = 0, // El ID se generará automáticamente
            PartidoSolicitanteId = solicitanteId,
            PartidoReceptorId = receptorId,
            Estado = EstadoAlianza.EnEspera,
            FechaSolicitud = DateTime.Now
        };

        await _repository.AddAsync(nueva);
        await _repository.SaveChangesAsync();
        return true;
    }
}
