using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Incoming : BaseEntity
    {
        public int Id {get; set;}
        public string SupplierName {get; set;}
        public string ItemName {get; set;}
        public string InvoiceNo {get; set;}
        public string Quantity {get; set;}
    }
}