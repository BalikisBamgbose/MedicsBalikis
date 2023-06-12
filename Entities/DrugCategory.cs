using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class DrugCategory : BaseEntity
    {
        public int DrugId {get; set;}
        public Drug Drug {get; set;}
        public int CategoryId {get; set;}
        public Category Category {get; set;}
    }
}