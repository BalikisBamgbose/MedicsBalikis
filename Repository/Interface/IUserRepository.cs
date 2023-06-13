using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(Expression<Func<User, bool>> expression);
    }
}