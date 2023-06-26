using Medics.Models;
using Medics.Models.Incoming;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Service.Interface
{
    public interface IIncomingService
    {
        BaseResponseModel CreateIncoming(CreateIncomingViewModel createIncomingDto);
        BaseResponseModel DeleteIncoming(string incomingId);
        BaseResponseModel UpdateIncoming(string incomingId, UpdateIncomingViewModel IncomingDto);
        IncomingResponseModel GetIncoming(string incomingId);
        IncomingsResponseModel GetAllIncomings();
        IEnumerable<SelectListItem> SelectIncomings();
    }
}