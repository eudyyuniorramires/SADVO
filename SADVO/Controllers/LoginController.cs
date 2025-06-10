using Microsoft.AspNetCore.Mvc;

namespace SADVO.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(int h)
        {
            return View();
        }

       
    }
}
