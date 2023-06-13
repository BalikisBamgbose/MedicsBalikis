using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Incoming
{  
        public class IncomingResponseModel : BaseResponseModel
           {
           public IncomingViewModel Data { get; set; }
           }

         public class IncomingsResponseModel : BaseResponseModel
           {
            public List<IncomingViewModel> Data { get; set; }
           } 
}