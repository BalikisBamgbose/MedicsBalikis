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
    public class DrugRepository : BaseRepository<Drug>, IDrugRepository
    {
        public DrugRepository(MedicsContext context) : base(context)
        {
        }

        public Drug GetDrug(Expression<Func<Drug, bool>> expression)
        {
            var drug = _context.Drugs
                 .Include(c => c.User)  
                 .Include(u => u.DrugCategorys)
                 .Include(qr => qr.Prices)
                 .Include(d=>d.Description)
                 .Include(c => c.Ages)
                 .SingleOrDefault(expression);

            return drug;
        }

        public List<DrugCategory> GetDrugByCategoryId(string CategoryId)
        {
            var drugs = _context.DrugCategory
                .Include(c => c.Category)
                .Include(c => c.Drug)
                .ThenInclude(c => c.User)
                .Where(c => c.CategoryId.Equals(CategoryId))
                .ToList();

            return drugs;
        }

        public List<Drug> GetDrugs()
        {
            var drugs = _context.Drugs
                .Include(uq => uq.Ages)
                .Include(c => c.Description)
                .Include(qr => qr.DrugCategorys)
                .ToList();

            return drugs;
        }

        public List<Drug> GetDrugs(Expression<Func<Drug, bool>> expression)
        {
            var drugs = _context.Drugs
               .Where(expression)
               .Include(u => u.User)
               .Include(c => c.Description)
               .Include(u => u.Ages)
               .Include(qr => qr.Prices)
               .ToList();

            return drugs;
        }

        public List<DrugCategory> SelectDrugByCategory()
        {
            var drugs = _context.DrugCategory
               .Include(c => c.Category)
               .Include(c => c.Drug)
               .ThenInclude(c => c.User)
               .ToList();

            return drugs;
        }

    }
}