using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Drug
{
    public class UpdateDrugViewModel
    {
        public List<string> DrugIds { get; set; }
        public string DrugId { get; set; }
        public List<Drug> Drugs { get; set; }
        
        [Required(ErrorMessage = "Enter Drug Name!")]
        [MinLength(3, ErrorMessage = "The minimum lenghh is 3")]
        [MaxLength(150, ErrorMessage = "The Maximum length is 150")]
        public string Drugs { get; set; }

        [Required(ErrorMessage = "Enter price")]
        public string Prices{ get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string IsClosed { get; set; } 
    }
}