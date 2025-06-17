using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Dtos.Usuario;
using SADVO.Core.Application.Interfaces;
using SADVO.Core.Application.ViewModels.LoginViewModel;

namespace SADVO.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioService _userService;

        public LoginController(IUsuarioService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel() {UserName = "",Password = ""});
        }


        [HttpPost]

        public async Task <IActionResult> Index(LoginViewModel vm)
        {

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
                return RedirectToRoute(new { controller = "Home", action = "Index", username = vm.UserName });

            }
            else 
            {
            
                ModelState.AddModelError("", "Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.");

            }

            vm.Password = "";
            return View(vm);
        }

        [HttpPost]
        public IActionResult Register(int h)
        {
            return View();
        }

       
    }
}
