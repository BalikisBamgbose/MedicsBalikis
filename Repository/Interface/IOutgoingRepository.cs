using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Repository.Interface
{
    public interface IOutgoingRepository : IRepository<Outgoing>
    {
        Outgoing GetOutgoing(string OutgoingId);
        List<Outgoing> GetAllOutgoing(Expression<Func<Outgoing, bool>> expression);

		List<Outgoing> GetOutgoings(string OutgoingIds);
    }
}