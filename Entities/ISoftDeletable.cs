using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public interface ISoftDeletable 
    {
        public bool IsDeleted { get; set; }
    }
}