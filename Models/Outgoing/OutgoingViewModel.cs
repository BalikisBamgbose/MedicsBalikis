using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Drug;

namespace Medics.Models.Outgoing
{
    public class OutgoingViewModel
    {
        public string Id {get; set;}
        public string Item {get; set;}
        public string Name {get; set;}  
        public string DeliveredTo {get; set;}  
        public string Quantity {get; set;}
        public string Purpose {get; set;}
        public string Sale {get; set;}
        public string CreatedBy { get; set;}       
        public List<DrugViewModel> Drugs { get; set; }
    }
}