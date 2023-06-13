using Medics.Models;
using Medics.Models.Age;
using Medics.Models.Role;
using Medics.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Service.Implementation
{
    public class Age : IAgeService
    {
        public BaseResponseModel CreateAge(CreateAgeViewModel request)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel DeleteAge(string ageId)
        {
            throw new NotImplementedException();
        }

        public RoleResponseModel GetAge(string ageId)
        {
            throw new NotImplementedException();
        }

        public RolesResponseModel GetAllAge()
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel UpdateAge(string ageId, UpdateAgeViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}