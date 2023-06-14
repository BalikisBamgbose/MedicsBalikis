using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class BaseEntity
    {
       public string Id {get; set;}= NewId.Next().ToSequentialGuid().ToString();
       public string CreatedBy {get; set;}
       public string ModifiedBy {get; set;}
       public DateTime DateCreated {get; set;}
       public DateTime DatePurchased {get; set;}
       public string MgfDate {get; set;}
       public string ExpDate {get; set;}
       public DateTime LastModified {get; set;}
       public bool IsDeleted {get; set;}
       public string InvoiceNo {get; set;}
       public string SupplyDate {get; set;}
       public string BillValue {get; set;}
       public string Bill {get; set;}
       public string DeliveryDate {get; set;}
       public string ReceiptNo {get; set;}
        
    }
}
