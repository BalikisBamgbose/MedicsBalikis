using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Drug;

namespace Medics.Models.Category
{
    public class CategoryViewModel 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<DrugViewModel> Drugs { get; set; }
    }
}