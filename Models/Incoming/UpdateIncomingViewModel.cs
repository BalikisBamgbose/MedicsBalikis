using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Incoming
{
    public class UpdateIncomingViewModel
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Enter Supplier Name")]
        public string SupplierName {get; set;}
        public List<string> Drugs { get; set; }
        public string ItemName {get; set;}
        public string InvoiceNo {get; set;}
        public string Quantity {get; set;} 
    }
}