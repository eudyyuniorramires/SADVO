using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.PuestoElectivo;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.PuestoElectivoViewMode;
using SADVO.Core.Domain.Entities;
using System.Xml;

namespace SADVO.Controllers
{
    public class PuestoElectivoController : Controller
    {

        private readonly IPuestoElectivo _puestoElectivoService;

        public PuestoElectivoController(IPuestoElectivo puestoElectivoService)
        {
            _puestoElectivoService = puestoElectivoService;
        }

        public async Task<IActionResult> Index()
        {
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

            return View("Save", new PuestoElectivoSaveViewModel() { Id = 0, Nombre = "", Descripcion = "", EstadoActivo = false });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PuestoElectivoSaveViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            PuestoElectivoDto dto = new() { Id = 0, Nombre = vm.Nombre, Descripcion = vm.Descripcion, EstaActivo = vm.EstadoActivo };

            await _puestoElectivoService.AddAsync(dto);
            return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

        }


        public async Task<IActionResult> Delete(int Id) 
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });
            }

            var dto = await _puestoElectivoService.GetById(Id);

            if (dto == null) 
            {

                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

            }

            PuestoElectivoViewModelDelete vm = new() { Id = dto.Id, Nombre = dto.Nombre, Descripcion = dto.Descripcion, EstaActivo = dto.EstaActivo };

            return View(vm);
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PuestoElectivoViewModelDelete vm)
        {
            if (!ModelState.IsValid) 
            {
                return View(vm);
            }

            await _puestoElectivoService.DeleteAsync(vm.Id);
            return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index"});

        }




        public async Task<IActionResult> Edit(int Id) 
        {
         
            if(!ModelState.IsValid)
            {

                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

            }
            ViewBag.EditMode = true;
            var dto = await _puestoElectivoService.GetById(Id);
            if(dto == null) 
            {

                return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });
            
            }

            PuestoElectivoSaveViewModel vm = new() { Id = dto.Id, Nombre = dto.Nombre, Descripcion = dto.Descripcion, EstadoActivo = dto.EstaActivo };
            return View("Save", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PuestoElectivoSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EditMode = true;
                return View("Save", vm);
            }

            PuestoElectivoDto dto = new() { Id = vm.Id,Nombre = vm.Nombre, Descripcion = vm.Descripcion, EstaActivo = vm.EstadoActivo };
            await _puestoElectivoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "PuestoElectivo", action = "Index" });

        }


    }
}
