using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    public class OutgoingController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
