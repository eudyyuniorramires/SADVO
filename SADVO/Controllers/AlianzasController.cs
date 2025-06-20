using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.Dtos;
using SADVO.Core.Application.ViewModels.AlianzaModel;

public class AlianzasController : Controller
{
    private readonly IAlianzaPoliticaService _alianzaService;
    private readonly IUsuarioSession _usuarioSession;

    public AlianzasController(IAlianzaPoliticaService alianzaService, IUsuarioSession usuarioSession)
    {
        _alianzaService = alianzaService;
        _usuarioSession = usuarioSession;
    }

    public async Task<IActionResult> Index()
    {
        var user = _usuarioSession.GetUserSession();

        if (!user.PartidoPoliticoId.HasValue)
        {
            TempData["Error"] = "Tu usuario no está asociado a un partido político.";
            return RedirectToAction("Index");
        }

        int partidoId = user.PartidoPoliticoId.Value;

        var recibidas = await _alianzaService.GetSolicitudesRecibidasAsync(partidoId);
        var enviadas = await _alianzaService.GetSolicitudesEnviadasAsync(partidoId);
        var vigentes = await _alianzaService.GetAlianzasVigentesAsync(partidoId);

        var model = new AlianzaListadoViewModel
        {
            SolicitudesEnviadas = enviadas,
            SolicitudesRecibidas = recibidas,
            AlianzasVigentes = vigentes
        };

        return View(model);
    }


    public async Task<IActionResult> Aceptar(int id)
    {
        var alianza = await _alianzaService.GetByIdDtoAsync(id);
        return View("ConfirmarAceptar", alianza);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmarAceptar(int id)
    {
        await _alianzaService.AceptarSolicitudAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Rechazar(int id)
    {
        var alianza = await _alianzaService.GetByIdDtoAsync(id);
        return View("ConfirmarRechazar", alianza);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmarRechazar(int id)
    {
        await _alianzaService.RechazarSolicitudAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        var alianza = await _alianzaService.GetByIdDtoAsync(id);
        return View("ConfirmarEliminar", alianza);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmarEliminar(int id)
    {
        await _alianzaService.EliminarSolicitudAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Crear()
{
    var user = _usuarioSession.GetUserSession();
    int partidoActualId = (int)user.PartidoPoliticoId.Value;

    var partidos = await _alianzaService.GetPartidosDisponiblesParaAlianzaAsync(partidoActualId);

    var model = new CrearAlianzaViewModel
    {
        PartidosDisponibles = partidos
    };

    return View(model);
}


    [HttpPost]
    public async Task<IActionResult> CrearSolicitud(int receptorId)
    {
        var user = _usuarioSession.GetUserSession();
        int solicitanteId = (int)user.PartidoPoliticoId.Value;

        await _alianzaService.CrearSolicitudAsync(solicitanteId, receptorId);
        return RedirectToAction("Index");
    }
}
