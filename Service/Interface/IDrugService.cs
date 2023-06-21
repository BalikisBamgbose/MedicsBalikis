using Medics.Models;
using Medics.Models.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Service.Interface
{
    public interface IDrugService
    {
        BaseResponseModel Create(CreateDrugViewModel request);
        BaseResponseModel Delete(string drugId);
        BaseResponseModel Update(string drugId, UpdateDrugViewModel updatedrugDto);
        DrugResponseModel GetDrug(string drugId);
        DrugsResponseModel GetAllDrugs();
        DrugsResponseModel GetDrugsByCategoryId(string categoryId);
        DrugsResponseModel DisplayDrug();
    }
}