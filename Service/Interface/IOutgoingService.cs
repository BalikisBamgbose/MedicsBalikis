
using Medics.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Outgoing;

namespace Medics.Service.Interface
{
    public interface IOutgoingService
    {
        BaseResponseModel CreateOutgoing(CreateOutgoingViewModel createOutgoingDto);
        BaseResponseModel DeleteOutgoing(string outgoingId);
        BaseResponseModel UpdateOutgoing(string outgoingId, UpdateOutgoingViewModel OutgoingDto);
        OutgoingResponseModel GetOutgoing(string outgoingId);
        IEnumerable<SelectListItem> SelectOutgoings();
    }
}