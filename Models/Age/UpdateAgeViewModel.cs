using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Age
{
    public class UpdateAgeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Input a specific age range")]
        public string Description { get; set; }
    }
}