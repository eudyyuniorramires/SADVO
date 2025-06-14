using Microsoft.AspNetCore.Mvc;
using SADVO.Core.Application.Interfaces;

namespace SADVO.Controllers
{
    public class PartidoPoliticoController : Controller
    {

        public readonly IPartidoPoliticoService _partidoPoliticoService;


        public PartidoPoliticoController(IPartidoPoliticoService partidoPoliticoService)
        {
            _partidoPoliticoService = partidoPoliticoService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
