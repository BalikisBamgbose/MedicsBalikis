using Medics.Context;
using Medics.Entities;
using Medics.Repository.Implementations;
using Medics.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Repository.Implementation
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MedicsContext context) : base(context)
        {
        }
    }
}