using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    public class DrugController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
