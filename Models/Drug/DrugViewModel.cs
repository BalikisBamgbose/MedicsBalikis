using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Category;

namespace Medics.Models.Drug
{
    public class DrugViewModel
    {
        public string UserId { get; set; }
        public string Id { get; set; }
       // public string Drug { get; set; }
        public string DrugName { get; set; }
        public string Description{ get; set; }
        public string Prices{ get; set; }
        public string Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public List<CategoryViewModel> DrugCategorys { get; set; }
        public List<DrugViewModel> Drugs { get; set; }
    }
}