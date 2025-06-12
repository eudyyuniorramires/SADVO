using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.PuestoElectivo;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.PuestoElectivoViewMode;

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

        
    }
}
