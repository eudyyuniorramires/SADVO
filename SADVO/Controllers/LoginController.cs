using Microsoft.AspNetCore.Http;
using SADVO.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.LoginViewModel;
using SADVO.Core.Application.ViewModels.UsuarioViewModel;
using Microsoft.AspNetCore.Identity;
using SADVO.Core.Domain.Entities;

namespace SADVO.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioService _userService;
        private readonly IUsuarioSession _usuarioSession;

        public LoginController(IUsuarioService userService,IUsuarioSession usuarioSession)
        {
            _userService = userService;
            _usuarioSession = usuarioSession;

        }
        public IActionResult Index()
        {
            UsuarioViewModel? usersession = _usuarioSession.GetUserSession();

            if (usersession != null)
            {
                return usersession.Rol switch
                {
                    // más seguro que usar ToString()
                    nameof(RolUsuario.Administrador) => RedirectToRoute(new { controller = "Home", action = "Index" }),
                    // << esta es la clave
                    nameof(RolUsuario.Dirigente) => RedirectToRoute(new { controller = "SADVOHome", action = "Index" }),
                    _ => RedirectToRoute(new { controller = "Login", action = "Index" }),
                };
            }

            return View(new LoginViewModel() {UserName = "",Password = ""});
        }


        [HttpPost]

        public async Task <IActionResult> Index(LoginViewModel vm)
        {
          

            if (_usuarioSession.HasUser())

            {  UsuarioViewModel?  usersession  = _usuarioSession.GetUserSession();
                return usersession.Rol switch
                {
                    // más seguro que usar ToString()
                    nameof(RolUsuario.Administrador) => RedirectToRoute(new { controller = "Home", action = "Index" }),
                    // << esta es la clave
                    nameof(RolUsuario.Dirigente) => RedirectToRoute(new { controller = "SADVOHome", action = "Index" }),
                    _ => RedirectToRoute(new { controller = "Login", action = "Index" }),
                };
            }


            if (!ModelState.IsValid) 
            {

                vm.Password = "";
                return View(vm);
            }

            UsuarioDto ?usuarioDto = await _userService.LoginAsync(new LoginDto()
            {
                UserName = vm.UserName,
                Password = vm.Password
            });

            if (usuarioDto != null)
            {
                UsuarioViewModel Usuariovm = new() { Email = usuarioDto.Email, Contrasena = usuarioDto.ContrasenaHash, Id = usuarioDto.Id ,Nombre = usuarioDto.Nombre,Apellido = usuarioDto.Apellido,RepeatContrasena = usuarioDto.ContrasenaHash ,EstaActivo = usuarioDto.EstaActivo,Rol = usuarioDto.Rol};
                HttpContext.Session.Set<UsuarioViewModel>("Usuario", Usuariovm); 

                if(Usuariovm.Rol == RolUsuario.Administrador.ToString())
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                return RedirectToRoute(new { controller = "SADVOHome", action = "Index", username = vm.UserName });

            }
            else 
            {
            
                ModelState.AddModelError("", "Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.");

            }

            vm.Password = "";
            return View(vm);
        }

        public IActionResult Logout()
        {
           HttpContext.Session.Remove("Usuario");
           return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        [HttpPost]
        public IActionResult Register(int h)
        {
            return View();
        }

       
    }
}
