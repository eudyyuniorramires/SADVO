using Microsoft.AspNetCore.Mvc;

namespace SADVO.Controllers
{
    public class CiudadanoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
