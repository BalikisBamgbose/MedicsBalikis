using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Incoming : BaseEntity
    {
        public string SupplierName {get; set;}
        public string ItemName {get; set;}
        public string Quantity {get; set;}
        public string InvoiceNo { get; set; }
        public string SupplyDate { get; set; }
        public string BillValue { get; set; }
        public string Bill { get; set; }
        public string DeliveryDate { get; set; }
        public string ReceiptNo { get; set; }
    }
}