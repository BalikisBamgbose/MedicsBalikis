using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Repository.Interface
{
    public interface IIncomingRepository : IRepository<Incoming>
    {
        Incoming GetIncoming(string incomingId);
        List<Incoming> GetIncomings(string incomingIds);
    }
}