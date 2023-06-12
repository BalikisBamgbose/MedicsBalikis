using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public interface ISoftDeletable : BaseEntity
    {
        public bool IsDeleted { get; set; }
    }
}