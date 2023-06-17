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
        public string DrugIds { get; set; }
        public string Drugs { get; set; }
        public string Prices{ get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string IsClosed { get; set; }
        public List<CategoryViewModel> DrugCategorys { get; set; }
    }
}