using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Outgoing
{
    public class OutgoingResponseModel : BaseResponseModel
    {
    public OutgoingViewModel Data { get; set; }
    }

    public class OutgoingsResponseModel : BaseResponseModel
    {
    public List<OutgoingViewModel> Data { get; set; }
    } 
    
}