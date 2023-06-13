using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.User
{
    public class UpdateUserViewModel
    {     
            public int Id { get; set; }

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