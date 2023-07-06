using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Outgoing
{
    public class UpdateOutgoingViewModel
    {
        public string Id {get; set;}
        public string Item {get; set;}
        public string Drug {get; set;}  
        public string DeliveredTo {get; set;}  
        public string Quantity {get; set;}
        public string Purpose {get; set;}
        public string Sale {get; set;}
    }
}