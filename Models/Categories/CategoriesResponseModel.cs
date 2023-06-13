using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Categories
{
            public class CategoriesResponseModel : BaseResponseModel
            {
                public CategoriesViewModel Data { get; set; }
            }

            public class CategoriessResponseModel : BaseResponseModel
            {
                public List<CategoriesViewModel> Data { get; set; }
            }
}