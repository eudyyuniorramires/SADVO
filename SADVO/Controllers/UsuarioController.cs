using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.UsuarioViewModel;
using SADVO.Core.Domain.Entities;

namespace SADVO.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        public async Task<IActionResult> Index()
        {

            var dtos = await _usuarioService.GetAll();

            var listaEntitiesVMS = dtos.Select(x => new UsuarioViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Email = x.Email,
                Contrasena = x.ContrasenaHash,
                RepeatContrasena = x.ContrasenaHash,
                EstaActivo = x.EstaActivo,
                Rol = x.Rol,
            }).ToList();
            return View(listaEntitiesVMS);
        }

        public IActionResult Create()
        {
            return View("Save", new UsuarioSaveViewModel()
            {
                Id = 0,
                Nombre = "",
                Apellido = "",
                Email = "",
                UserName = "",
                Contrasena = "",
                RepeatContrasena = "",
                EstaActivo = true,
                Rol = "Administrador"
            });
        }


        [HttpPost]

        public async Task<IActionResult> Create(UsuarioSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            GuardarUsuarioDto dto = new()
            {
                Id = 0,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                UserName = vm.UserName,
                Email = vm.Email,
                ContrasenaHash = vm.Contrasena,
                EstaActivo = vm.EstaActivo,
                Rol = vm.Rol
            };

            await _usuarioService.AddAsync(dto);
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }



        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            var dto = await _usuarioService.GetById(Id);

            if (dto == null)
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            UsuarioViewModelDelete vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                EstaActivo = dto.EstaActivo,
                Contrasena = dto.ContrasenaHash,
                Rol = dto.Rol?.ToString() ?? "DefaultRole"
            };

            return View("Delete", vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmacion(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            await _usuarioService.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            ViewBag.EditMode = true;
            var dto = await _usuarioService.GetById(id);
            if (dto == null)
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            UsuarioSaveViewModel vm = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                UserName = dto.UserName,
                Email = dto.Email,
                Contrasena = dto.ContrasenaHash,
                RepeatContrasena = dto.ContrasenaHash,
                EstaActivo = dto.EstaActivo,
                Rol = dto.Rol?.ToString() ?? "DefaultRole"
            };

            return View("Save", vm);
        }

        [HttpPost]
       
        public async Task<IActionResult> Edit(UsuarioSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EditMode = true;
                return View("Save", vm);
            }

            GuardarUsuarioDto dto = new()
            {
                Id = vm.Id,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                UserName = vm.UserName,
                Email = vm.Email,
                ContrasenaHash = vm.Contrasena,
                EstaActivo = vm.EstaActivo,
                Rol = vm.Rol
            };

            await _usuarioService.UpdateAsync(dto);
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });



        }
    }

}


        
