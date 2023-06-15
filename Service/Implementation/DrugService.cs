using Medics.Entities;
using Medics.Models;
using Medics.Models.Drug;
using Medics.Repository.Interface;
using Medics.Service.Interface;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Medics.Service.Implementation
{
    public class DrugService : IDrugService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public DrugService(
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }
        public BaseResponseModel Create(CreateDrugViewModel request)
        {
            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _unitOfWork.Users.Get(userIdClaim);

            var drug = new Drug
            {
                UserId = user.Id,
                DrugName = request.DrugName,
                ImageUrl = request.ImageUrl,
                CreatedBy = createdBy,
            };

            var category = _unitOfWork.Category.GetAllByIds(request.CategoryIds);

            var DrugCategorys = new HashSet<DrugCategory>();

            foreach (var categorys in category)
            {
                var drugCategory = new DrugCategory
                {
                    CategoryId = categorys.Id,
                    DrugId = drug.Id,
                    Category = categorys,
                    Drug = drug,
                    CreatedBy = createdBy
                };

                DrugCategorys.Add(drugCategory);
            }

               drug.DrugCategorys = DrugCategorys;

            try
            {
                _unitOfWork.Drugs.Create(drug);
                _unitOfWork.SaveChanges();
                response.Message = "Drug created successfully!";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to create drug: {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel Delete(string drugId)
        {

            var response = new BaseResponseModel();

            Expression<Func<Drug, bool>> expression = (q => (q.Id == drugId)
                                        && (q.Id == drugId
                                        && q.IsDeleted == false
                                        && q.IsClosed == false));

            var drugExist = _unitOfWork.Drugs.Exists(expression);
            
            if (!drugExist)
            {
                response.Message = "Drug does not exist!";
                return response;
            }


            var drug = _unitOfWork.Drugs.Get(drugId);
            drug.IsDeleted = true;

            try
            {
                _unitOfWork.Drugs.Update(drug);
                _unitOfWork.SaveChanges();
                response.Message = "Drug deleted successfully!";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Drug delete failed: {ex.Message}";
                return response;
            }
        }

        public DrugsResponseModel DisplayDrug()
        {
            throw new NotImplementedException();
        }

        public DrugsResponseModel GetAllDrugs()
        {
            throw new NotImplementedException();
        }

        public DrugResponseModel GetDrug(string drugId)
        {
            throw new NotImplementedException();
        }

        public DrugsResponseModel GetDrugsByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel Update(string drugId, UpdateDrugViewModel updatedrugDto)
        {
            throw new NotImplementedException();
        }
    }
}