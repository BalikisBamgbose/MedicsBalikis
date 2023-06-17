using Medics.Entities;
using Medics.Models;
using Medics.Models.Incoming;
using Medics.Models.Outgoing;
using Medics.Repository.Interface;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Service.Implementation
{
    public class OutgoingService : IOutgoingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OutgoingService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public BaseResponseModel CreateOutgoing(CreateOutgoingViewModel request)
        {
            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            var isOutgoingExist = _unitOfWork.Outgoings.Exists(c => c.Name == request.Name);

            if (isOutgoingExist)
            {
                response.Message = $"Outgoing Item with name {request.Name} already exist!";
                return response;
            }

            var outgoing = new Outgoing()
            {
                Item = request.Item,
                Name = request.Name,
                Quantity = request.Quantity,
                Purpose = request.Purpose,
                CreatedBy = createdBy,
                DeliveredTo = request.DeliveredTo

            };

            try
            {
                _unitOfWork.Outgoings.Create(outgoing);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Outgoing item created successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to create Incoming. {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeleteOutgoing(string outgoingId)
        {
            var response = new BaseResponseModel();
            var outgoingExist = _unitOfWork.Incomings.Exists(x => x.Id == outgoingId);

            if (!outgoingExist)
            {
                response.Message = "Outgoing does not exist!";
                return response;
            }

            var outgoings = _unitOfWork.Outgoings.Get(outgoingId);
            outgoings.IsDeleted = true;

            try
            {
                _unitOfWork.Outgoings.Update(outgoings);
                _unitOfWork.SaveChanges();
                response.Message = "Outgoing deleted successfully.";
                response.Status = true;

                return response;
            }
            catch (Exception)
            {
                response.Message = "Outgoing delete failed";
                return response;
            }
        }

        public OutgoingsResponseModel GetAllOutgoing()
        {
            var response = new OutgoingsResponseModel();

            try
            {
                var outgoings = _unitOfWork.Outgoings.GetAll(i => i.IsDeleted == false);

                if (outgoings is null || outgoings.Count == 0)
                {
                    response.Message = "No outgoings found!";
                    return response;
                }

                response.Data = outgoings
                   .Select(i => new OutgoingViewModel
                   {
                       Id = i.Id,
                       Item = i.Item,
                       Name = i.Name,
                       Quantity = i.Quantity,
                       Purpose = i.Purpose,
                       CreatedBy = i.CreatedBy,
                       DeliveredTo = i.DeliveredTo
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

        public OutgoingResponseModel GetOutgoing(string outgoingId)
        {
            var response = new OutgoingResponseModel();
            var outgoingExist = _unitOfWork.Outgoings.Exists(f =>
                                (f.Id == outgoingId)
                                && (f.Id == outgoingId
                                && f.IsDeleted == false));

            if (!outgoingExist)
            {
                response.Message = $"Outgoing Drug with id {outgoingId} does not exist.";
                return response;
            }

            try
            {
                var outgoings = _unitOfWork.Outgoings.Get(outgoingId);

                response.Message = "Success";
                response.Status = true;
                response.Data = new OutgoingViewModel
                {
                    Id = outgoings.Id,
                    Item = outgoings.Item,
                    Name = outgoings.Name,
                    Quantity = outgoings.Quantity,
                    Purpose = outgoings.Purpose,
                    DeliveredTo = outgoings.DeliveredTo
                    
                };
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }

            return response;
        }

        public BaseResponseModel UpdateOutgoing(string outgoingId, UpdateOutgoingViewModel request)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            var isOutgoingExist = _unitOfWork.Outgoings.Exists(f => f.Id == outgoingId);
                                           

            if (!isOutgoingExist)
            {
                response.Message = "Outgoing drug does not exist!";
                return response;
            }

            var outgoing = _unitOfWork.Outgoings.Get(outgoingId);

            outgoing.Item = outgoing.Item;
            outgoing.Name = outgoing.Name; 
            outgoing.Quantity = outgoing.Quantity;
            outgoing.Purpose = outgoing.Purpose;
            outgoing.DeliveredTo = outgoing.DeliveredTo;

            try
            {
                _unitOfWork.Outgoings.Update(outgoing);
                _unitOfWork.SaveChanges();
                response.Message = "Outgoing drug updated successfully.";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update the outgoing drug: {ex.Message}";
                return response;
            }
        }

        public IEnumerable<SelectListItem> SelectOutgoings()
        {
            return _unitOfWork.Outgoings.SelectAll().Select(f => new SelectListItem()
            {
                Text = f.Item,
                Value = f.Id
            });
        }
    }
}