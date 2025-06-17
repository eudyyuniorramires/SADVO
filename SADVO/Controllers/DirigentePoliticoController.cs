using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using SADVO.Core.Application.Dtos.DirigentePolitico;
using SADVO.Core.Application.Dtos.PartidoPolitico;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.Services;
using SADVO.Core.Application.ViewModels.DirigentePoliticoViewModel;
using SADVO.Core.Application.ViewModels.PartidoPoliticoViewModel;
using SADVO.Core.Application.ViewModels.UsuarioViewModel;
using SADVO.Core.Domain.Entities;
using System.Xml;

namespace SADVO.Controllers
{
    public class DirigentePoliticoController : Controller
    {

        public readonly IDirigentePartidoService _dirigentePartidoService;
        public readonly IUsuarioService _UsuarioService;
        public readonly IPartidoPoliticoService _partidoSevice;


        public DirigentePoliticoController(IDirigentePartidoService dirigentePartidoService, IUsuarioService usuarioService,IPartidoPoliticoService partidoPoliticoService)
        {
            _dirigentePartidoService = dirigentePartidoService;
            _UsuarioService = usuarioService;
            _partidoSevice = partidoPoliticoService;
        }



        public async Task<IActionResult> Index()
        {
            var dtos = await _dirigentePartidoService.GetAll();

            var listaEntitiesVMS = dtos.Select(x => new DirigentePoliticoViewModel()
            {
                Id = x.Id,
                PartidoPoliticoId = x.PartidoPoliticoId,
                UsuarioId = x.UsuarioId,

                // Agrega estos campos si están en el ViewModel
                NombreUsuario = $"{x.Usuario?.Nombre} {x.Usuario?.Apellido}",
                NombrePartido = x.PartidoPolitico?.Nombre,
                Siglas = x.PartidoPolitico.Siglas
            }).ToList();

            return View(listaEntitiesVMS);
        }


        public async Task <IActionResult> Create()
        {
            await CargarCombos(); // <- carga los combos

            return View("Save", new DirigentePoliticoSaveViewModel() { Id = 0, UsuarioId = 0, PartidoPoliticoId = 0 });
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirigentePoliticoSaveViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }
            ViewBag.Usuarios = new SelectList(await _UsuarioService.GetAll(), "Id", "NombreCompleto");
            ViewBag.Partidos = new SelectList(await _UsuarioService.GetAll(), "Id", "Nombre");


            DirigentePartidoDto dto = new() { Id = 0, UsuarioId = vm.UsuarioId , PartidoPoliticoId= vm.PartidoPoliticoId };

            await _dirigentePartidoService.AddAsync(dto);

            return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });
            }

            var dto = await _dirigentePartidoService.GetById(Id);

            if (dto == null)
            {

                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });

            }



           DirigentePoliticoDeleteViewModel vm = new() { Id = dto.Id, UsuarioId = dto.UsuarioId , PartidoPoliticoId = dto.PartidoPoliticoId };
            return View(vm);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            var result = await _dirigentePartidoService.DeleteAsync(id);

            if (!result)
            {

                TempData["Error"] = "No se puede eliminar el Dirigente Politico ";

            }
            else
            {

                TempData["Succes"] = "Se elimino el Dirigente Politico";

            }

            return RedirectToAction("Index");



        }


        public async Task<IActionResult> Edit(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });
            }

            ViewBag.EditMode = true;
            var dto = await _dirigentePartidoService.GetById(Id);
            if (dto == null)
            {

                return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });

            }

            DirigentePoliticoSaveViewModel vm = new()
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
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            DirigentePartidoDto dto = new() { Id = vm.Id, UsuarioId = vm.UsuarioId, PartidoPoliticoId = vm.PartidoPoliticoId };

            await _dirigentePartidoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "DirigentePolitico", action = "Index" });


        }

        private async Task CargarCombos()
        {
            // Obtenemos todos los usuarios activos con rol Dirigente
            var todosLosDirigentes = await _UsuarioService.GetAll();

            var dirigentesDisponibles = new List<UsuarioDto>(); // Ajusta el tipo según lo que devuelva tu servicio

            RolUsuario rolConvertido = Enum.Parse<RolUsuario>("Dirigente");

            foreach (var dirigente in todosLosDirigentes)
            {
                // Filtrar activos y con rol Dirigente
                if (dirigente.EstaActivo && dirigente.Rol.ToString() == "Dirigente")
                {
                    bool yaAsignado = await _dirigentePartidoService.ExistsByUsuarioId(dirigente.Id);
                    if (!yaAsignado)
                        dirigentesDisponibles.Add(dirigente); // ✅ ahora coincide el tipo
                }
            }

            // Creamos el SelectList con los dirigentes disponibles
            ViewBag.Usuarios = new SelectList(
                dirigentesDisponibles.Select(u => new { u.Id, NombreCompleto = $"{u.Nombre} {u.Apellido}" }),
                "Id",
                "NombreCompleto"
            );

            // Filtramos partidos activos
            var partidos = (await _partidoSevice.GetAll())
                .Where(p => p.EstaActivo)
                .Select(p => new { p.Id, p.Nombre });

            ViewBag.Partidos = new SelectList(partidos, "Id", "Nombre");
        }



    }
}
