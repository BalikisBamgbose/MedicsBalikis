using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Drug : BaseEntity
    {
       public string UserId { get; set; }
       public string Description { get; set; }
       public Drug Drugs { get; set; }
       public ICollection<DrugCategory> DrugCategory { get; set; } = new HashSet<DrugCategory>();
       public string Prices{ get; set; }
       public string Quantity { get; set; }
       public string ImageUrl { get; set; }
       public string IsClosed { get; set; }
    }
}