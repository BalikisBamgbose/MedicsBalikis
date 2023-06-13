using Medics.Models.Role;
using Medics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Service.Interface
{
    public interface IRoleService
    {      
            BaseResponseModel CreateRole(CreateRoleViewModel request);
            BaseResponseModel DeleteRole(string roleId);
            BaseResponseModel UpdateRole(string roleId, UpdateRoleViewModel request);
            RoleResponseModel GetRole(string roleId);
            RolesResponseModel GetAllRole();
    }
}