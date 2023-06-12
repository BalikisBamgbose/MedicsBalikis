using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Age
{
    public class AgeResponseModel : BaseResponseModel
    {
        public AgeViewModel Data { get; set; }
    }

    public class AgeResponseModel : BaseResponseModel
    {
        public List<AgeViewModel> Data { get; set; }
    }
}