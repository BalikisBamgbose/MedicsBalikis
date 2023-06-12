using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class BaseEntity : BaseEntity
    {
       public int Id {get; set;}= NewId.Next().ToSequentialGuid().ToString();
       public string CreatedBy {get; set;}
       public string ModifiedBy {get; set;}
       public string DateCreated {get; set;}
       public string DatePurchased {get; set;}
       public string MgfDate {get; set;}
       public string ExpDate {get; set;}
       public string LastModified {get; set;}
       public string IsDeleted {get; set;}
       public string InvoiceNo {get; set;}
       public string SupplyDate {get; set;}
       public string BillValue {get; set;}
       public string Bill {get; set;}
       public string DeliveryDate {get; set;}
       public string ReceiptNo {get; set;}
        
    }
}
