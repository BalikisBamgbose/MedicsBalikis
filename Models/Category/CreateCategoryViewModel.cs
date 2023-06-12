using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Category
{
    public class CreateCategoryViewModel
    {
       [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
        public string Description { get; set; } 
        
    }
}