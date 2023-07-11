using AspNetCoreHero.ToastNotification.Abstractions;
using Medics.Models.Outgoing;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OutgoingController : Controller
    {
        private readonly IOutgoingService _outgoingService;
        private readonly IDrugService _drugService;
        private readonly INotyfService _notyf;

        public OutgoingController(IOutgoingService outgoingService, INotyfService notyf, IDrugService drugService)
        {
            _outgoingService = outgoingService;
            _notyf = notyf;
            _drugService = drugService;
        }
        public IActionResult Index()
        {
            var response = _outgoingService.GetAllOutgoing();

            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;

            return View(response.Data);
        }
        public IActionResult CreateOutgoing()
        {
            ViewBag.Drugs = _drugService.SelectDrugs();
            ViewData["Message"] = "";
            ViewData["Status"] = false;
            return View();
        }

        [HttpPost]
        public IActionResult CreateOutgoing(CreateOutgoingViewModel request)
        {
            var response = _outgoingService.CreateOutgoing(request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Outgoing"); ;
        }

        public IActionResult GetOutgoingDetail(string id)
        {
            var response = _outgoingService.GetOutgoing(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Outgoing");
            }

            return View(response.Data);
        }

        public IActionResult Update(string id)
        {
            var response = _outgoingService.GetOutgoing(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Outgoing");
            }

            var viewModel = new UpdateOutgoingViewModel
            {
                Id = response.Data.Id,
                Item= response.Data.Item,
                Drug = response.Data.Drug,
                DeliveredTo = response.Data.DeliveredTo,
               // Purpose = response.Data.Purpose,
                Quantity = response.Data.Quantity,
                Sale= response.Data.Sale

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateOutgoingViewModel request)
        {
            var response = _outgoingService.UpdateOutgoing(id, request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View(request);
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Outgoing");
        }

        [HttpPost]
        public IActionResult DeleteOutgoing(string id)
        {
            var response = _outgoingService.DeleteOutgoing(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Outgoing");
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Outgoing");
        }
    }
}
