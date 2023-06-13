using Medics.Context;
using Medics.Entities;
using Medics.Repository.Implementations;
using Medics.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MedicsContext context) : base(context)
        {
        }

        public User GetUser(Expression<Func<User, bool>> expression)
        {
            return _context.Users
                .Include(x => x.Role)
                .SingleOrDefault(expression);
        }
    }
}