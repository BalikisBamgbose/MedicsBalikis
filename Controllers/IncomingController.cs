using AspNetCoreHero.ToastNotification.Abstractions;
using Medics.Models.Incoming;
using Medics.Models.Outgoing;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncomingController : Controller
    {
        private readonly IIncomingService _incomingService;
        private readonly INotyfService _notyf;

        public IncomingController(IIncomingService incomingService, INotyfService notyf)
        {
            _incomingService = incomingService;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            var response = _incomingService.GetAllIncoming();

            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;

            return View(response.Data);
        }
        public IActionResult CreateIncoming()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateIncoming(CreateIncomingViewModel request)
        {
            var response = _incomingService.CreateIncoming(request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Incoming"); ;
        }

        public IActionResult GetIncomingDetail(string id)
        {
            var response = _incomingService.GetIncoming(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Incoming");
            }

            return View(response.Data);
        }

        public IActionResult Update(string id)
        {
            var response = _incomingService.GetIncoming(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Incoming");
            }

            var viewModel = new UpdateIncomingViewModel
            {
                Id = response.Data.Id,
                ItemName = response.Data.ItemName,
                SupplierName = response.Data.SupplierName,
                InvoiceNo = response.Data.InvoiceNo,
                Quantity = response.Data.Quantity
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(string id, UpdateIncomingViewModel request)
        {
            var response = _incomingService.UpdateIncoming(id, request);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View(request);
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Incoming");
        }

        [HttpPost]
        public IActionResult DeleteIncoming(string id)
        {
            var response = _incomingService.DeleteIncoming(id);

            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return RedirectToAction("Index", "Incoming");
            }

            _notyf.Success(response.Message);

            return RedirectToAction("Index", "Incoming");
        }
    }
}
