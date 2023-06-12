using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Medics.Models.Age;
namespace Medics.Models.Categories
{
    public class CategoriesViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<AgeViewModel> Age { get; set; }
    }
}