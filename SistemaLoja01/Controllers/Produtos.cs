using Microsoft.AspNetCore.Mvc;

namespace SistemaLoja01.Controllers
{
    public class Produtos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
