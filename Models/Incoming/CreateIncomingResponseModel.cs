using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Incoming
{
    public class CreateIncomingResponseModel
    {

        [Required(ErrorMessage = "Enter Supplier Name")]
        public string SupplierName {get; set;}
        
        [MinLength(5, ErrorMessage = "The minimum length acceptable is 5")]
        [MaxLength(200)]
        public List<string> Drugs { get; set; }
        public string ItemName {get; set;}
        public string InvoiceNo {get; set;}
        public string Quantity {get; set;} 
    }
}