using Medics.Models.Role;
using Medics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Age;

namespace Medics.Service.Interface
{
    public interface IAgeService
    {
            BaseResponseModel CreateAge(CreateAgeViewModel request);
            BaseResponseModel DeleteAge(string ageId);
            BaseResponseModel UpdateAge(string ageId, UpdateAgeViewModel request);
            RoleResponseModel GetAge(string ageId);
            RolesResponseModel GetAllAge();
        
    }
}