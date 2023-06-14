using Medics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Repository.Interface
{
    public interface IDrugRepository : IRepository<Drug>
    {
        List<Drug> GetDrugs();
        List<Drug> GetDrugs(Expression<Func<Drug, bool>> expression);
        Drug GetDrug(Expression<Func<Drug, bool>> expression);
        List<DrugCategory> GetDrugByCategoryId(string id);
        List<DrugCategory> SelectDrugByCategory();
    }
}