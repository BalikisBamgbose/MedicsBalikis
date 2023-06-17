using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
