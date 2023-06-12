using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Drug;

namespace Medics.Models.Return
{
    public class ReturnViewModel 
    {
        public string Name {get; set;}
        public string ReturnDate {get; set;}
        public string ReturnId {get; set;}
        public string Quantity {get; set;}
        public string InvoiceNo {get; set;}
        public string ReturnedBy {get; set;}
        public List<DrugViewModel> Drugs { get; set; }
    }
}