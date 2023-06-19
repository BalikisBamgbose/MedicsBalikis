using AspNetCoreHero.ToastNotification.Abstractions;
using Medics.Models.Drug;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    public class DrugController : Controller
    {
        private readonly IDrugService _drugService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotyfService _notyf;

        public DrugController(
            IDrugService drugService,
            ICategoryService categoryService,
            IHttpContextAccessor httpContextAccessor,
            INotyfService notyf)
        {
            _drugService = drugService;
            _categoryService = categoryService;
            _httpContextAccessor = httpContextAccessor;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            var drugs = _drugService.GetAllDrugs();
            ViewData["Message"] = drugs.Message;
            ViewData["Status"] = drugs.Status;

            return View(drugs.Data);
        }

        public IActionResult Create()
        {
            ViewBag.Categorys = _categoryService.SelectCategories();
            ViewData["Message"] = "";
            ViewData["Status"] = false;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDrugViewModel request)
        {
            var response = _drugService.Create(request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Drug");
        }

        public IActionResult GetDrugByCategory(string id)
        {
            var response = _drugService.GetDrugsByCategoryId(id);
            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;

            return View(response.Data);
        }

        public IActionResult GetDrugDetail(string id)
        {
            var response = _drugService.GetDrug(id);
            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;

            return View(response.Data);
        }

        public IActionResult Update(string id)
        {
            var response = _drugService.GetDrug(id);

            return View(response.Data);
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateDrugViewModel request)
        {
            var response = _drugService.Update(id, request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);

                return RedirectToAction("Index", "Home");
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Question");
        }

        [HttpPost]
        public IActionResult DeleteDrug([FromRoute] string id)
        {
            var response = _drugService.Delete(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);
            return RedirectToAction("Index", "Drug");

        }  
    }
}
