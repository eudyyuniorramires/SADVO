using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SADVO.Core.Application.Dtos.DirigentePolitico;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.DirigentePoliticoViewModel;
using SADVO.Core.Application.ViewModels.UsuarioViewModel;

namespace SADVO.Controllers
{
    public class DirigentePoliticoController : Controller
    {
        private readonly IDirigentePartidoService _dirigentePartidoService;
        private readonly IUsuarioService _UsuarioService;
        private readonly IPartidoPoliticoService _partidoSevice;
        private readonly IUsuarioSession _usuarioSession;

        public DirigentePoliticoController(
            IDirigentePartidoService dirigentePartidoService,
            IUsuarioService usuarioService,
            IPartidoPoliticoService partidoPoliticoService,
            IUsuarioSession usuarioSession)
        {
            _dirigentePartidoService = dirigentePartidoService;
            _UsuarioService = usuarioService;
            _partidoSevice = partidoPoliticoService;
            _usuarioSession = usuarioSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var dtos = await _dirigentePartidoService.GetAll();

            var listaEntitiesVMS = dtos.Select(x => new DirigentePoliticoViewModel()
            {
                Id = x.Id,
                PartidoPoliticoId = x.PartidoPoliticoId,
                UsuarioId = x.UsuarioId,
                NombreUsuario = $"{x.Usuario?.Nombre} {x.Usuario?.Apellido}",
                NombrePartido = x.PartidoPolitico?.Nombre,
                Siglas = x.PartidoPolitico?.Siglas
            }).ToList();

            return View(listaEntitiesVMS);
        }

        public async Task<IActionResult> Create()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            await CargarCombos();
            return View("Save", new DirigentePoliticoSaveViewModel() { Id = 0, UsuarioId = 0, PartidoPoliticoId = 0 });
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirigentePoliticoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
            {
                await CargarCombos();
                return View("Save", vm);
            }

            DirigentePartidoDto dto = new() { Id = 0, UsuarioId = vm.UsuarioId, PartidoPoliticoId = vm.PartidoPoliticoId };
            await _dirigentePartidoService.AddAsync(dto);

            return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });

            var dto = await _dirigentePartidoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });

            var vm = new DirigentePoliticoDeleteViewModel
            {
                Id = dto.Id,
                UsuarioId = dto.UsuarioId,
                PartidoPoliticoId = dto.PartidoPoliticoId
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var result = await _dirigentePartidoService.DeleteAsync(id);
            TempData[result ? "Succes" : "Error"] = result
                ? "Se eliminó el Dirigente Político"
                : "No se pudo eliminar el Dirigente Político";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });

            var dto = await _dirigentePartidoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });

            ViewBag.EditMode = true;
            await CargarCombos();

            var vm = new DirigentePoliticoSaveViewModel
            {
                Id = dto.Id,
                UsuarioId = dto.UsuarioId,
                PartidoPoliticoId = dto.PartidoPoliticoId
            };

            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DirigentePoliticoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
            {
                await CargarCombos();
                return View("Save", vm);
            }

            DirigentePartidoDto dto = new()
            {
                Id = vm.Id,
                UsuarioId = vm.UsuarioId,
                PartidoPoliticoId = vm.PartidoPoliticoId
            };

            await _dirigentePartidoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });
        }

        private async Task CargarCombos()
        {
            var todosLosDirigentes = await _UsuarioService.GetAll();
            var dirigentesDisponibles = new List<UsuarioDto>();

            foreach (var dirigente in todosLosDirigentes)
            {
                if (dirigente.EstaActivo && dirigente.Rol.ToString() == "Dirigente")
                {
                    bool yaAsignado = await _dirigentePartidoService.ExistsByUsuarioId(dirigente.Id);
                    if (!yaAsignado)
                        dirigentesDisponibles.Add(dirigente);
                }
            }

            ViewBag.Usuarios = new SelectList(
                dirigentesDisponibles.Select(u => new { u.Id, NombreCompleto = $"{u.Nombre} {u.Apellido}" }),
                "Id",
                "NombreCompleto"
            );

            var partidos = (await _partidoSevice.GetAll())
                .Where(p => p.EstaActivo)
                .Select(p => new { p.Id, p.Nombre });

            ViewBag.Partidos = new SelectList(partidos, "Id", "Nombre");
        }
    }
}
