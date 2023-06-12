using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Incoming
{
    public class IncomingResponseModel
    {
        public class IncomingResponseModel : BaseResponseModel
           {
           public IncomingViewModel Data { get; set; }
           }

         public class IncomingResponseModel : BaseResponseModel
           {
            public List<IncomingViewModel> Data { get; set; }
           } 
    }
}