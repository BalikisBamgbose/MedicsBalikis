using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system.Medics.Models.Categories;
namespace Medics.Models.Age
{
    public class AgeViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; } 
        public List<CategoriesViewModel> Categories { get; set; }
    }
}