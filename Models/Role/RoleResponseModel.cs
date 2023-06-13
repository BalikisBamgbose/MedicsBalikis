using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Role
{
    
    public class RoleResponseModel : BaseResponseModel
    {
        public RoleViewModel Data { get; set; }
    }

    public class RolesResponseModel : BaseResponseModel
    {
        public List<RoleViewModel> Data { get; set; }
    }
   
}