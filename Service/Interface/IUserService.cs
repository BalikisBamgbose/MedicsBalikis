using Medics.Models.Auth;
using Medics.Models.User;
using Medics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Service.Interface
{
    public interface IUserService
    {
        UserResponseModel GetUser(string userId);
        BaseResponseModel Register(SignUpViewModel request, string roleName = null);
        UserResponseModel Login(LoginViewModel request);
    }
}