using Medics.Entities;
using Medics.Models;
using Medics.Models.Incoming;
using Medics.Repository.Interface;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Service.Implementation
{
    public class IncomingService : IIncomingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IncomingService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public BaseResponseModel CreateIncoming(CreateIncomingViewModel request)
        {
            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            var isIncomingExist = _unitOfWork.Incomings.Exists(c => c.ItemName == request.ItemName);

            if (isIncomingExist)
            {
                response.Message = $"Incoming with name {request.ItemName} already exist!";
                return response;
            }

            var incoming = new Incoming()
            {
                ItemName = request.ItemName,
                SupplierName = request.SupplierName,
                Quantity = request.Quantity,
                InvoiceNo = request.InvoiceNo,
                SupplyDate = request.SupplyDate,
                Bill = request.Bill,
                CreatedBy = createdBy
            };

            try
            {
                _unitOfWork.Incomings.Create(incoming);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Incoming created successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to create Incoming. {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeleteIncoming(string incomingId)
        {
            var response = new BaseResponseModel();
            var incomingExist = _unitOfWork.Incomings.Exists(x => x.Id == incomingId);

            if (!incomingExist)
            {
                response.Message = "Incoming does not exist!";
                return response;
            }

            var incomings = _unitOfWork.Incomings.Get(incomingId);
            incomings.IsDeleted = true;

            try
            {
                _unitOfWork.Incomings.Update(incomings);
                _unitOfWork.SaveChanges();
                response.Message = "Incoming deleted successfully.";
                response.Status = true;

                return response;
            }
            catch (Exception)
            {
                response.Message = "Incoming delete failed";
                return response;
            }
        }

        public IncomingsResponseModel GetAllIncoming()
        {
            var response = new IncomingsResponseModel();

            try
            {
                var incomings = _unitOfWork.Incomings.GetAll(i => i.IsDeleted == false);

                if (incomings is null || incomings.Count == 0)
                {
                    response.Message = "No incomings found!";
                    return response;
                }

                response.Data = incomings
                   .Select(i => new IncomingViewModel
                   {
                       Id = i.Id,
                       ItemName = i.ItemName,
                       SupplierName = i.SupplierName,
                       SupplyDate = i.SupplyDate
                   }).ToList();

                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                return response;
            }

            return response;
        }

        public IncomingResponseModel GetIncoming(string incomingId)
        {
            var response = new IncomingResponseModel();
            var incomingExist = _unitOfWork.Incomings.Exists(f =>
                                (f.Id == incomingId)
                                && (f.Id == incomingId
                                && f.IsDeleted == false));

            if (!incomingExist)
            {
                response.Message = $"Incoming Drug with id {incomingId} does not exist.";
                return response;
            }

            try
            {
                var incomings = _unitOfWork.Incomings.Get(incomingId);

                response.Message = "Success";
                response.Status = true;
                response.Data = new IncomingViewModel
                {
                    Id = incomings.Id,
                    ItemName = incomings.ItemName,
                    SupplierName = incomings.SupplierName,
                    SupplyDate = incomings.SupplyDate
                };
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }

            return response;
        }

        public BaseResponseModel UpdateIncoming(string incomingId, UpdateIncomingViewModel request)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            Expression<Func<Incoming, bool>> expression = f =>
                                                (f.Id == incomingId)
                                                && (f.Id == incomingId
                                                && f.IsDeleted == false);

            var isIncomingExist = _unitOfWork.Incomings.Exists(expression);

            if (!isIncomingExist)
            {
                response.Message = "Incoming drug does not exist!";
                return response;
            }

            var incoming = _unitOfWork.Incomings.Get(incomingId);

            incoming.ItemName = incoming.ItemName;
            incoming.SupplierName = request.SupplierName;
            incoming.ModifiedBy = modifiedBy;

            try
            {
                _unitOfWork.Incomings.Update(incoming);
                _unitOfWork.SaveChanges();
                response.Message = "Incoming drug updated successfully.";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update the incoming drug: {ex.Message}";
                return response;
            }
        }

        public IEnumerable<SelectListItem> SelectIncomings()
        {
            return _unitOfWork.Incomings.SelectAll().Select(f => new SelectListItem()
            {
                Text = f.ItemName,
                Value = f.Id
            });
        }
    }
}