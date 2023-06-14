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
    public class CategoriesRepository : BaseRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(MedicsContext context) : base(context)
        {
        }
    }
}