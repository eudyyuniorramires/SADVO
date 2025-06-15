using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.PartidoPoliticoViewModel;
using System.Xml;

namespace SADVO.Controllers
{
    public class PartidoPoliticoController : Controller
    {

        public readonly IPartidoPoliticoService _partidoPoliticoService;


        public PartidoPoliticoController(IPartidoPoliticoService partidoPoliticoService)
        {
            _partidoPoliticoService = partidoPoliticoService;
        }
        public async Task<IActionResult> Index()
        {
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

            return View("Save", new PartidoPoliticoSaveViewModel() { Id = 0, Nombre = "", Descripcion = "", Siglas = "", LogoPath = "", EstaActivo = false });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PartidoPoliticoSaveViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            PartidoPoliticoDto dto = new() { Id = 0, Nombre = vm.Nombre, Descripcion = vm.Descripcion, Siglas = vm.Siglas, LogoPath = vm.LogoPath, EstaActivo = vm.EstaActivo };

            await _partidoPoliticoService.AddAsync(dto);

            return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });
            }

            var dto = await _partidoPoliticoService.GetById(Id);

            if (dto == null)
            {

                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });

            }



            PartidoPoliticoDeleteViewModel vm = new() { Id = dto.Id, Nombre = dto.Nombre, Descripcion = dto.Descripcion, Siglas = dto.Siglas, LogoPath = dto.LogoPath, EstaActivo = dto.EstaActivo };

            return View(vm);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            var result = await _partidoPoliticoService.DeleteAsync(id);

            if (!result)
            {

                TempData["Error"] = "No se puede eliminar el PartidoPolitico";

            }
            else 
            {

                TempData["Succes"] = "Se elimino el PartidoPolitico";
            
            }

            return RedirectToAction("Index");

            

        }


        public async Task<IActionResult> Edit(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });
            }

            ViewBag.EditMode = true;
            var dto = await _partidoPoliticoService.GetById(Id);
            if (dto == null)
            {

                return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });

            }

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
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            PartidoPoliticoDto dto = new() { Id = vm.Id, Nombre = vm.Nombre, Descripcion = vm.Descripcion, Siglas = vm.Siglas, LogoPath = vm.LogoPath, EstaActivo = vm.EstaActivo };

            await _partidoPoliticoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "PartidoPolitico", action = "Index" });


        }
    }
}