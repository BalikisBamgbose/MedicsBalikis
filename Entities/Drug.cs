using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class Drug : BaseEntity
    {
       public int  Id { get; set; }
       public string UserId { get; set; }
       public string Drugs { get; set; }
       public ICollection<Drug> Drugs { get; set; } = new HashSet<User>();
       public string Prices{ get; set; }
       public string Quantity { get; set; }
       public string ImageUrl { get; set; }
       public string IsClosed { get; set; }
    }
}