using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Repository.Interface
{
    public interface IReturnRepository : IRepository<Return>
    {
        Return GetReturn(string returnId);
        List<Return> GetReturns(string returnIds);
    }
}