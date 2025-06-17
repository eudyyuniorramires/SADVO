using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.Ciudadano;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.Ciudadano;
using System.Reflection.Metadata.Ecma335;

namespace SADVO.Controllers
{
    public class CiudadanoController : Controller
    {

        private readonly ICiudadanoService _ciudadanoService;
        private readonly IUsuarioSession _usuarioSession;


        public CiudadanoController(ICiudadanoService ciudadanoService, IUsuarioSession usuarioSession)
        {
            _ciudadanoService = ciudadanoService;
            _usuarioSession = usuarioSession;
        }

        public async Task<IActionResult> Index()
        {

            if (!_usuarioSession.HasUser()) 
            {

                return RedirectToRoute(new { controller = "Login", action = "Index" });

            }

            var dtos = await _ciudadanoService.GetAll();

            var listaEntitiesVMS = dtos.Select(x => new CiudadanoViewModel()
            {
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Email = x.Email,
                DocumentoIdentidad = x.DocumentoIdentidad,
                EstaActivo = x.EstaActivo,
                Id = x.Id
            }).ToList();

            return View(listaEntitiesVMS);
        }





        public IActionResult Create()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            return View("Save", new CiudadanoSaveViewModel() { Id = 0, Nombre = "", Apellido = "", Email = "", DocumentoIdentidad = "", EstaActivo = false });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CiudadanoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return View("Save", vm);

            CiudadanoDto dto = new()
            {
                Id = 0,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Email = vm.Email,
                DocumentoIdentidad = vm.DocumentoIdentidad,
                EstaActivo = vm.EstaActivo
            };

            await _ciudadanoService.AddAsync(dto);
            return RedirectToRoute(new { controller = "Ciudadano", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "Ciudadano", action = "Index" });

            var dto = await _ciudadanoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "Ciudadano", action = "Index" });

            CiudadanoDeleteViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                DocumentoIdentidad = dto.DocumentoIdentidad,
                EstaActivo = dto.EstaActivo
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            var result = await _ciudadanoService.DeleteAsync(id);

            if (!result)
                TempData["Error"] = "El ciudadano no pudo ser eliminado";
            else
                TempData["Succes"] = "El ciudadano fue eliminado correctamente";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "Ciudadano", action = "Index" });

            ViewBag.EditMode = true;
            var dto = await _ciudadanoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "Ciudadano", action = "Index" });

            CiudadanoSaveViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                DocumentoIdentidad = dto.DocumentoIdentidad,
                EstaActivo = dto.EstaActivo
            };

            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CiudadanoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return View("Save", vm);

            CiudadanoDto dto = new()
            {
                Id = vm.Id,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Email = vm.Email,
                DocumentoIdentidad = vm.DocumentoIdentidad,
                EstaActivo = vm.EstaActivo
            };

            await _ciudadanoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "Ciudadano", action = "Index" });
        }

    }
}