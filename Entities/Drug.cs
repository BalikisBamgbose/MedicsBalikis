using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Drug : BaseEntity
    {
       public string UserId { get; set; }
       public User User { get; set; }
       public string Description { get; set; }
       public string AgeId { get; set; }    
       public Category Ages { get; set; }
       public ICollection<DrugCategory> DrugCategory { get; set; } = new HashSet<DrugCategory>();
       public decimal Prices{ get; set; }
       public string Quantity { get; set; }
       public string ImageUrl { get; set; }
       public string IsClosed { get; set; }
    }
}