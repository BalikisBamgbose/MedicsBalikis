using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Drug
{
    public class CreateDrugViewModel
    {
        public List<string> Drugs { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Enter Drug Name!")]
        [MinLength(3, ErrorMessage = "The minimum lenghh is 3")]
        [MaxLength(150, ErrorMessage = "The Maximum length is 150")]
        public string Drug { get; set; }

        [Required(ErrorMessage = "Enter price")]
        public string Prices{ get; set; }
        public string Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string IsClosed { get; set; }
    }
}