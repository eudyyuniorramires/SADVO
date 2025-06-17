using Microsoft.AspNetCore.Mvc;

namespace SADVO.Controllers
{
    public class SADVOHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
