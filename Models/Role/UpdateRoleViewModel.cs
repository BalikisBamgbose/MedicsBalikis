using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Role
{
    public class UpdateRoleViewModel
    {
        public class UpdateRoleViewModel
    {
        public string Id { get; set; }

        [ReadOnly(true)]
        public string RoleName { get; set; }

        [MinLength(5, ErrorMessage = "The minimum length acceptable is 5")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
    }
}