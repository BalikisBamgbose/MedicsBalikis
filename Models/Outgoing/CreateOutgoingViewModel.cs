using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Models.Outgoing
{
    public class CreateOutgoingViewModel
    {
        [Required(ErrorMessage = "Enter an Item")]
        public string Item {get; set;}
        public string DrugId { get; set; }

        [Required(ErrorMessage = "Enter Ougoing Item Name")]
        //public Drugs drug {get; set;}  
        public string DeliveredTo {get; set;}  
        public string Quantity {get; set;}

        [Required(ErrorMessage = "Enter reason for outgoing item")]
        [MinLength  (5, ErrorMessage = "Minimum Lenght is 5")]
        [MaxLength(200)]
        public string Purpose {get; set;}
        public string Sale {get; set;}
    }
}