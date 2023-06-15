using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Category
{ 
    public class CategoryResponseModel : BaseResponseModel
    {
            public CategoryViewModel Data { get; set; }
    }

    public class CategorysResponseModel : BaseResponseModel
    {
        public List<CategoryViewModel> Data { get; set; }
    }
    
}