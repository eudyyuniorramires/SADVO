using SADVO.Core.Application.Dtos;
using SADVO.Core.Application.Dtos.Alianza;
using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using System.ComponentModel.Design;

public class AlianzaPoliticaService : IAlianzaPoliticaService
{
    private readonly IAlianzaPoliticaRepository _repository;
    private readonly IEleccionesService _eleccionService;
    private readonly IPartidoPoliticoRepository _partidoRepository;

    public AlianzaPoliticaService(IAlianzaPoliticaRepository repository, IEleccionesService eleccionService, IPartidoPoliticoRepository partidoRepository)
    {
        _repository = repository;
        _eleccionService = eleccionService;
        _partidoRepository = partidoRepository;
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

        return await _repository.CrearAlianzaAsync(solicitanteId, receptorId);
    }


    public async Task<List<PartidoPoliticoDto>> GetPartidosDisponiblesParaAlianzaAsync(int partidoActualId)
    {
        var todos = await _partidoRepository.GetActivosAsync();

        var alianzas = await _repository.GetAlianzasAceptadasAsync(partidoActualId);
        var solicitudes = await _repository.GetSolicitudesEnviadasAsync(partidoActualId);
        var recibidas = await _repository.GetSolicitudesRecibidasAsync(partidoActualId);

        var noDisponibles = new HashSet<int>();

        // Ya aliados
        foreach (var a in alianzas)
        {
            noDisponibles.Add(a.PartidoSolicitanteId == partidoActualId ? a.PartidoReceptorId : a.PartidoSolicitanteId);
        }

        // Ya enviadas en espera
        foreach (var s in solicitudes.Where(s => s.Estado == EstadoAlianza.EnEspera))
        {
            noDisponibles.Add(s.PartidoReceptorId);
        }

        // Ya recibidas en espera
        foreach (var r in recibidas.Where(r => r.Estado == EstadoAlianza.EnEspera))
        {
            noDisponibles.Add(r.PartidoSolicitanteId);
        }

        // Excluir partidos no disponibles o el propio
        var disponibles = todos
            .Where(p => p.Id != partidoActualId && !noDisponibles.Contains(p.Id))
            .Select(p => new PartidoPoliticoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Siglas = p.Siglas
            })
            .ToList();

        return disponibles;
    }

}
