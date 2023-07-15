using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Drug
{
    public class UpdateDrugViewModel
    {
        public List<string> DrugIds { get; set; }
        public string DrugId { get; set; }
        public string Description { get; set; }
        public List<string> Drugs { get; set; }
        
       
        [MinLength(3, ErrorMessage = "The minimum lenghh is 3")]
        [MaxLength(150, ErrorMessage = "The Maximum length is 150")]
        public string DrugName { get; set; }

        public string Prices{ get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string IsClosed { get; set; } 
    }
}