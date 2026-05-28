using Microsoft.AspNetCore.Mvc;

namespace Farmacia2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Redirige directamente al formulario de registro
            return RedirectToAction("Create", "Producto");
        }
    }
}