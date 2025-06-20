using Microsoft.EntityFrameworkCore;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Context;

public class AlianzaPoliticaRepository : IAlianzaPoliticaRepository
{
    private readonly ApplicationDbContext _context;

    public AlianzaPoliticaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AlianzaPolitica>> GetSolicitudesRecibidasAsync(int partidoReceptorId)
    {
        return await _context.AlianzaPoliticas
            .Include(a => a.PartidoSolicitante)
            .Where(a => a.PartidoReceptorId == partidoReceptorId && a.Estado == EstadoAlianza.EnEspera)
            .ToListAsync();
    }

    public async Task<List<AlianzaPolitica>> GetSolicitudesEnviadasAsync(int partidoSolicitanteId)
    {
        return await _context.AlianzaPoliticas
            .Include(a => a.PartidoReceptor)
            .Where(a => a.PartidoSolicitanteId == partidoSolicitanteId)
            .ToListAsync();
    }

    public async Task<List<AlianzaPolitica>> GetAlianzasAceptadasAsync(int partidoId)
    {
        return await _context.AlianzaPoliticas
            .Include(a => a.PartidoSolicitante)
            .Include(a => a.PartidoReceptor)
            .Where(a =>
                a.Estado == EstadoAlianza.Aceptada &&
                (a.PartidoSolicitanteId == partidoId || a.PartidoReceptorId == partidoId))
            .ToListAsync();
    }

    public async Task<AlianzaPolitica?> GetByIdAsync(int id)
    {
        return await _context.AlianzaPoliticas
            .Include(a => a.PartidoSolicitante)
            .Include(a => a.PartidoReceptor)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> ExisteSolicitudActivaEntreAsync(int partidoAId, int partidoBId)
    {
        return await _context.AlianzaPoliticas.AnyAsync(a =>
            a.Estado == EstadoAlianza.EnEspera &&
            (
                (a.PartidoSolicitanteId == partidoAId && a.PartidoReceptorId == partidoBId) ||
                (a.PartidoSolicitanteId == partidoBId && a.PartidoReceptorId == partidoAId)
            ));
    }

    public async Task AddAsync(AlianzaPolitica alianza)
    {
        await _context.AlianzaPoliticas.AddAsync(alianza);
    }

    public async Task DeleteAsync(AlianzaPolitica alianza)
    {
        _context.AlianzaPoliticas.Remove(alianza);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CrearAlianzaAsync(int solicitanteId, int receptorId)
    {
        // Validar existencia de partidos
        var solicitanteExiste = await _context.PartidoPoliticos.AnyAsync(p => p.Id == solicitanteId);
        var receptorExiste = await _context.PartidoPoliticos.AnyAsync(p => p.Id == receptorId);

        if (!solicitanteExiste || !receptorExiste)
            return false;

        // Validar duplicidad de solicitud (opcional, puedes moverla aquí también)
        var existe = await _context.AlianzaPoliticas
            .AnyAsync(a =>
                a.PartidoSolicitanteId == solicitanteId &&
                a.PartidoReceptorId == receptorId &&
                a.Estado == EstadoAlianza.EnEspera);

        if (existe)
            return false;

        // Crear nueva solicitud
        var nueva = new AlianzaPolitica
        {
            PartidoSolicitanteId = solicitanteId,
            PartidoReceptorId = receptorId,
            Estado = EstadoAlianza.EnEspera,
            FechaSolicitud = DateTime.Now
        };

        _context.AlianzaPoliticas.Add(nueva);
        await _context.SaveChangesAsync();

        return true;
    }

}
