using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Return : BaseEntity
    {
        public string Name {get; set;}
        public string ReturnDate {get; set;}
        public string ReturnId {get; set;}
        public string Quantity { get; set; }
        public string ReturnedBy {get; set;}
        public string InvoiceNo { get; set; }
        public string SupplyDate { get; set; }
        public string BillValue { get; set; }
        public string Bill { get; set; }
        public string Purpose { get; set; }
        public string DeliveryDate { get; set; }
        public string ReceiptNo { get; set; }
    }
}