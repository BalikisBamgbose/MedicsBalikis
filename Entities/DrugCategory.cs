using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class DrugCategory : BaseEntity
    {
        public string UserId { get; set; }
        public User user{ get; set; }
        public string DrugId {get; set;}
        public Drug Drug {get; set;}
        public string CategoryId {get; set;}
        public Category Category {get; set;}
    }
}