using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Category : BaseEntity
    {
         public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DrugCategory> DrugCategorys { get; set; } = new HashSet<DrugCategory>();
    }
}