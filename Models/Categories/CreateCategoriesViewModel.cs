using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Categories
{
    public class CreateCategoriesViewModel
    {
        [Required(ErrorMessage = "Categories name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}