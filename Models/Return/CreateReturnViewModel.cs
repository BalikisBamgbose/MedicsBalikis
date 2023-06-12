using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Return
{
    public class CreateReturnViewModel
    {
        [Required(ErrorMessage = "Enter Item Name")]
        public string Name {get; set;}
        public string ReturnDate {get; set;}
        public string ReturnId {get; set;}
        public string Quantity {get; set;}
        public string InvoiceNo {get; set;}
        public string ReturnedBy {get; set;}
    }
}