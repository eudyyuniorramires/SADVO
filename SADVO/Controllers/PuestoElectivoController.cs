using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.PuestoElectivo;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.PuestoElectivoViewMode;

namespace SADVO.Controllers
{
    public class PuestoElectivoController : Controller
    {
        private readonly IPuestoElectivo _puestoElectivoService;
        private readonly IUsuarioSession _usuarioSession;

        public PuestoElectivoController(IPuestoElectivo puestoElectivoService, IUsuarioSession usuarioSession)
        {
            _puestoElectivoService = puestoElectivoService;
            _usuarioSession = usuarioSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var dtos = await _puestoElectivoService.GetAll();

            var listaEntitiesVMS = dtos.Select(x => new PuestoElectivoViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                EstadoActivo = x.EstaActivo
            }).ToList();

            return View(listaEntitiesVMS);
        }

        public IActionResult Create()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            return View("Save", new PuestoElectivoSaveViewModel()
            {
                Id = 0,
                Nombre = "",
                Descripcion = "",
                EstadoActivo = false
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PuestoElectivoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return View("Save", vm);

            PuestoElectivoDto dto = new()
            {
                Id = 0,
                Nombre = vm.Nombre,
                Descripcion = vm.Descripcion,
                EstaActivo = vm.EstadoActivo
            };

            await _puestoElectivoService.AddAsync(dto);
            return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

            var dto = await _puestoElectivoService.GetById(Id);

            if (dto == null)
                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

            PuestoElectivoViewModelDelete vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                EstaActivo = dto.EstaActivo
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var result = await _puestoElectivoService.DeleteAsync(id);

            TempData[result ? "Succes" : "Error"] = result
                ? "Se eliminó el Puesto Electivo."
                : "No se pudo eliminar el Puesto Electivo.";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

            ViewBag.EditMode = true;
            var dto = await _puestoElectivoService.GetById(Id);

            if (dto == null)
                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

            PuestoElectivoSaveViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                EstadoActivo = dto.EstaActivo
            };

            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PuestoElectivoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
            {
                ViewBag.EditMode = true;
                return View("Save", vm);
            }

            PuestoElectivoDto dto = new()
            {
                Id = vm.Id,
                Nombre = vm.Nombre,
                Descripcion = vm.Descripcion,
                EstaActivo = vm.EstadoActivo
            };

            await _puestoElectivoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });
        }
    }
}
