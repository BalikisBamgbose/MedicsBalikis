using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Medics.Models.Drug;
namespace Medics.Models.Category
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<DrugViewModel> Drugs { get; set; }
    }
}