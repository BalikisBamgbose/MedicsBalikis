using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Categories
{
    public class UpdateCategoriesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Categories name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}