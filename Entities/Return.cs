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
    }
}