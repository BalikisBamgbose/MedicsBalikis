using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    public class IncomingController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
