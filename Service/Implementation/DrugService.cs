using Medics.Entities;
using Medics.Models;
using Medics.Models.Category;
using Medics.Models.Drug;
using Medics.Repository.Interface;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System.Security.Claims;

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
                Quantity = request.Quantity,
                Prices = request.Prices,
                Description= request.Description,
                ImageUrl = request.ImageUrl,
               
            };

            var category = _unitOfWork.Categorys.GetAllByIds(request.CategoryIds);

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
            var response = new DrugsResponseModel();

            try
            {
                var drugs = _unitOfWork.Drugs.GetDrugs();

                if (drugs.Count == 0)
                {
                    response.Message = "No drug found!";
                    return response;
                }

                response.Data = drugs
                    .Where(q => !q.IsDeleted)
                    .Select(drug => new DrugViewModel
                    { 
                        Id = drug.Id,                        
                        Quantity = drug.Quantity,
                        Prices = drug.Prices.ToString(),
                        ImageUrl = drug.ImageUrl,
                        UserId = drug.UserId,
                        DrugCategorys= drug.DrugCategorys
                            .Where(c => !c.IsDeleted)
                            .Select(c => new CategoryViewModel
                            {
                                Id = c.Category.Id,
                                Name = c.Category.Name,
                                Description = c.Category.Description,

                            })
                            .ToList()
                    }).ToList();

                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }

            return response;
        }

        public DrugsResponseModel GetAllDrugs()
        {
            var response = new DrugsResponseModel();

            try
            {
                var IsInRole = _httpContextAccessor.HttpContext.User.IsInRole("Admin");
                var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                Expression<Func<Drug, bool>> expression = q => q.UserId == userIdClaim;

                var drugs = IsInRole ? _unitOfWork.Drugs.GetDrugs() : _unitOfWork.Drugs.GetDrugs(expression);

                if (drugs.Count == 0)
                {
                    response.Message = "No drug found!";
                    return response;
                }

                response.Data = drugs
                    .Where(q => q.IsDeleted == false)
                    .Select(drug => new DrugViewModel
                    {
                        Id = drug.Id,
                        //Quantity = drug.Quantity,
                        Drugs = drug.DrugName,
                        Description = drug.Description,
                        UserId = drug.UserId,
                        DrugCategorys = drug.DrugCategorys
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Category.Id,
                            Name = c.Category.Name,
                            Description = c.Category.Description,
                        }).ToList(),
                    }).ToList();

                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.StackTrace}";
                return response;
            }

            return response;
        }

        public DrugResponseModel GetDrug(string DrugIds)
        {
            var response = new DrugResponseModel();
            var drugExist = _unitOfWork.Drugs.Exists(q => q.Id == DrugIds && q.IsDeleted == false);
            var IsInRole = _httpContextAccessor.HttpContext.User.IsInRole("Admin");
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var drug = new Drug();

            if (!drugExist)
            {
                response.Message = $"Drug with id {DrugIds} does not exist!";
                return response;
            }

            drug = IsInRole ? _unitOfWork.Drugs.GetDrug(q => q.Id == DrugIds && !q.IsDeleted) : 
            _unitOfWork.Drugs.GetDrug(q => q.Id == DrugIds
                                                && q.UserId == userIdClaim
                                                && !q.IsDeleted);

            if (drug is null)
            {
                response.Message = "Drug not found!";
                return response;
            }

            response.Message = "Success";
            response.Status = true;
            response.Data = new DrugViewModel
            {
                Id = drug.Id,
                Quantity = drug.Quantity,
                Prices = drug.Prices.ToString(),
                ImageUrl = drug.ImageUrl,
                UserId = drug.UserId,
                DrugCategorys = drug.DrugCategorys
                            .Where(q => q.IsDeleted == false)
                            .Select(c => new CategoryViewModel
                            {
                                Id = c.Category.Id,
                                Name = c.Category.Name,
                                Description = c.Category.Description,
                            }).ToList(),
            };

            return response;
        }

        public DrugsResponseModel GetDrugsByCategoryId(string categoryId)
        {
            var response = new DrugsResponseModel();

            try
            {
                var drugs = _unitOfWork.Drugs.GetDrugByCategoryId(categoryId);

                if (drugs.Count == 0)
                {
                    response.Message = "No drug found!";
                    return response;
                }

                response.Data = drugs
                                    .Select(drug => new DrugViewModel
                                    {
                                        Id = drug.Id,
                                        Quantity = drug.Drug.Quantity,
                                        Prices = drug.Drug.Prices.ToString(),
                                        ImageUrl = drug.Drug.ImageUrl,
                                        UserId = drug.Drug.UserId,
                                        Drugs = drug.Drug.DrugName,
                                    }).ToList();

                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = $"An error occured: {ex.StackTrace}";
                return response;
            }

            return response;
        }

        public IEnumerable<SelectListItem> SelectDrugs()
        {
            return _unitOfWork.Drugs.SelectAll(c => c.IsDeleted == false).Select(dru => new SelectListItem()
            {
                Text = dru.DrugName,
                Value = dru.Id
            }
            );
        }

        public BaseResponseModel Update(string drugId, UpdateDrugViewModel request)
        {
            var response = new BaseResponseModel();
            var modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var questionExist = _unitOfWork.Drugs.Exists(c => c.Id == drugId);
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _unitOfWork.Users.Get(userIdClaim);

            if (!questionExist)
            {
                response.Message = "Drug does not exist!";
                return response;
            }


            var drug = _unitOfWork.Drugs.Get(drugId);

            if (drug.UserId != user.Id)
            {
                response.Message = "You cannot update this drug";
                return response;
            }

            drug.Description = request.Description;
            drug.ModifiedBy = modifiedBy;
            drug.DrugName= request.Drug;

            try
            {
                _unitOfWork.Drugs.Update(drug);
                _unitOfWork.SaveChanges();
                response.Message = "Drug updated successfully!";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update the Drug: {ex.Message}";
                return response;
            }
        }
    }
}