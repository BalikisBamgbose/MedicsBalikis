using Medics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Outgoing : BaseEntity
    {
        public string Item {get; set;}
        public Drug Drug {get; set;}
        public string DrugId { get; set; }
        public string DeliveredTo {get; set;}  
        public string Quantity {get; set;}
        public Purpose Purpose {get; set;}
        public string Sale {get; set;}
        public string InvoiceNo { get; set; }
        public string SupplyDate { get; set; }
        public string BillValue { get; set; }
        public string Bill { get; set; }
        public string DeliveryDate { get; set; }
        public string ReceiptNo { get; set; }
    }
}