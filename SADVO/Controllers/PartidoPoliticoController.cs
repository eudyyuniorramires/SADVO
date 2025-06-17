using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.PartidoPoliticoViewModel;

namespace SADVO.Controllers
{
    public class PartidoPoliticoController : Controller
    {
        private readonly IPartidoPoliticoService _partidoPoliticoService;
        private readonly IUsuarioSession _usuarioSession;

        public PartidoPoliticoController(IPartidoPoliticoService partidoPoliticoService, IUsuarioSession usuarioSession)
        {
            _partidoPoliticoService = partidoPoliticoService;
            _usuarioSession = usuarioSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var dtos = await _partidoPoliticoService.GetAll();

            var listaEntitiesVMS = dtos.Select(x => new PartidoPoliticoViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Siglas = x.Siglas,
                LogoPath = x.LogoPath,
                EstaActivo = x.EstaActivo
            }).ToList();

            return View(listaEntitiesVMS);
        }

        public IActionResult Create()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            return View("Save", new PartidoPoliticoSaveViewModel()
            {
                Id = 0,
                Nombre = "",
                Descripcion = "",
                Siglas = "",
                LogoPath = "",
                EstaActivo = false
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PartidoPoliticoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            PartidoPoliticoDto dto = new()
            {
                Id = 0,
                Nombre = vm.Nombre,
                Descripcion = vm.Descripcion,
                Siglas = vm.Siglas,
                LogoPath = vm.LogoPath,
                EstaActivo = vm.EstaActivo
            };

            await _partidoPoliticoService.AddAsync(dto);

            return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });

            var dto = await _partidoPoliticoService.GetById(Id);

            if (dto == null)
                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });

            PartidoPoliticoDeleteViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Siglas = dto.Siglas,
                LogoPath = dto.LogoPath,
                EstaActivo = dto.EstaActivo
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var result = await _partidoPoliticoService.DeleteAsync(id);

            TempData[result ? "Succes" : "Error"] = result
                ? "Se eliminó el Partido Político"
                : "No se puede eliminar el Partido Político";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });

            ViewBag.EditMode = true;
            var dto = await _partidoPoliticoService.GetById(Id);

            if (dto == null)
                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });

            PartidoPoliticoSaveViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Siglas = dto.Siglas,
                LogoPath = dto.LogoPath,
                EstaActivo = dto.EstaActivo
            };

            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartidoPoliticoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            PartidoPoliticoDto dto = new()
            {
                Id = vm.Id,
                Nombre = vm.Nombre,
                Descripcion = vm.Descripcion,
                Siglas = vm.Siglas,
                LogoPath = vm.LogoPath,
                EstaActivo = vm.EstaActivo
            };

            await _partidoPoliticoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });
        }
    }
}
