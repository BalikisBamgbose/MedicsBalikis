using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Medics.Models.Drug;
namespace Medics.Models.Incoming
{
    public class IncomingViewModel
    {
        public int Id {get; set;}
        public string SupplierName {get; set;}
        public string ItemName {get; set;}
        public string InvoiceNo {get; set;}
        public string Quantity {get; set;}
        public List<DrugViewModel> Drugs { get; set; }
    }
}