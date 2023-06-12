using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.User
{
    public class CreateUserViewMoel
    {
        public class CreateUserViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
    }
}