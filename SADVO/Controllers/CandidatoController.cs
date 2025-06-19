using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SADVO.Core.Application.Helpers;
using SADVO.Core.Application.Dtos.Candidato;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.CandidatoViewModel;
using SADVO.Core.Application.ViewModels.Ciudadano;
using SADVO.Core.Application.ViewModels.UsuarioViewModel;
using SADVO.Middlewares;
using SADVO.Core.Application.Services;
using SADVO.Core.Domain.Interfaces;
using SADVO.Core.Domain.Entities;

namespace SADVO.Controllers
{
    public class CandidatoController : Controller
    {

        private readonly ICandidatosService _candidatoService;
        private readonly IUsuarioSession _usuarioSession;
        private readonly  IDirigentePartidoService _dirigentePartidoService ;


        public CandidatoController(ICandidatosService candidatoService, IUsuarioSession usuarioSession,IDirigentePartidoService dirigentePartidoService)
        {
            _candidatoService = candidatoService;
            _usuarioSession = usuarioSession;
            _dirigentePartidoService = dirigentePartidoService;
        }   
        public async Task< IActionResult> Index()
        {
            if (!_usuarioSession.HasUser())
            {

                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            var user = _usuarioSession.GetUserSession();
            int usuarioId = user.Id;

            var dtos = await _candidatoService.GetAllByDirigenteAsync(usuarioId);

            var listaEntitiesVMS = dtos.Select(x => new CandidatoViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                EstaActivo = x.EstaActivo,
                PartidoPoliticoId = x.PartidoPoliticoId,
                FotoPath = x.FotoPath,
                NombrePartido = (string)x.NombrePartido
            }).ToList();


            return View(listaEntitiesVMS);


            
        }

        public IActionResult Create()
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            return View("Save", new CandidatoSaveViewModel() { Id = 0, Nombre = "", Apellido = "", EstaActivo = true, PartidoPoliticoId = 0, FotoPath = "" , PartidoPoliticoNombre = ""});


        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidatoSaveViewModel vm)
        {
            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            var usuarioSession = HttpContext.Session.Get<UsuarioViewModel>("Usuario");
            int usuarioId = usuarioSession.Id;

            var asignacion = await _dirigentePartidoService.GetByUsuarioIdAsync(usuarioId);

            if (asignacion == null || asignacion.PartidoPoliticoId == 0)
            {
                ModelState.AddModelError("", "Debe estar asignado a un partido político para crear candidatos.");
                return View("Save", vm);
            }

            // Puedes usar el nombre del partido si lo necesitas en la vista

            CandidatoDto dto = new()
            {
                Id = 0,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                EstaActivo = vm.EstaActivo,
                FotoPath = vm.FotoPath,
                // PartidoPoliticoId se asignará en el Service usando el usuarioId
            };

            await _candidatoService.AddAsync(dto, usuarioId);

            return RedirectToRoute(new { controller = "Candidato", action = "Index" });
        }




        public async Task<IActionResult> Delete(int Id) 
        {

            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "Candidato", action = "Index" });

            var dto = await _candidatoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "Candidato", action = "Index" });

            CandidatoDeleteViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                EstaActivo = dto.EstaActivo,
                PartidoPoliticoId = dto.PartidoPoliticoId,
                FotoPath = dto.FotoPath
            };

            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmacion(int Id) 
        {

            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "Candidato", action = "Index" });

            var dto = await _candidatoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "Candidato", action = "Index" });

            await _candidatoService.DeleteAsync(dto.Id);

            return RedirectToRoute(new { controller = "Candidato", action = "Index" });


        }

        public async Task<IActionResult> Edit(int Id) 
        {

            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if (!ModelState.IsValid)
                return RedirectToRoute(new { controller = "Candidato", action = "Index" });

            ViewBag.EditMode = true;
            var dto = await _candidatoService.GetById(Id);
            if (dto == null)
                return RedirectToRoute(new { controller = "Candidato", action = "Index" });

            CandidatoSaveViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                EstaActivo = dto.EstaActivo,
                PartidoPoliticoId = dto.PartidoPoliticoId,
                FotoPath = dto.FotoPath
            };

            return View("Save", vm);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(CandidatoSaveViewModel vm) 
        {

            if (!_usuarioSession.HasUser())
                return RedirectToRoute(new { controller = "Login", action = "Index" });

            if(!ModelState.IsValid)
            {

                return View("Save", vm);

            }

            CandidatoDto dto = new()
            {
                Id = vm.Id,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                EstaActivo = vm.EstaActivo,
                PartidoPoliticoId = vm.PartidoPoliticoId,
                FotoPath = vm.FotoPath
            };

            await _candidatoService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "Candidato", action = "Index" });
        }




    }
}
