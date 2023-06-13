using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.User
{    
        public class UserResponseModel : BaseResponseModel
            {
                public UserViewModel Data { get; set; }
            }

            public class UsersResponseModel : BaseResponseModel
            {
                public List<UserViewModel> Data { get; set; }
            }
}