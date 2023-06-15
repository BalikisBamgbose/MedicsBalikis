using Medics.Entities;
using Medics.Models.Category;
using Medics.Models;
using Medics.Repository.Interface;
using Medics.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Medics.Models.Categories;

namespace Medics.Service.Implementation
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public BaseResponseModel CreateCategories(CreateCategoriesViewModel request)
        {
            var response = new BaseResponseModel();
            var createdBy = _httpContextAccessor.HttpContext.User.Identity.Name;

            var isCategoriesExist = _unitOfWork.Categories.Exists(c => c.Name == request.Name);

            if (isCategoriesExist)
            {
                response.Message = "Categories already exist!";
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                response.Message = "Categories name is required!";
                return response;
            }

            var categories = new Categories
            {
                Name = request.Name,
                Description = request.Description,
                CreatedBy = createdBy
            };

            try
            {
                _unitOfWork.Categories.Create(categories);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Categories created successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Failed to create category at this time: {ex.Message}";
                return response;
            }
        }

        public BaseResponseModel DeleteCategories(string categoriesId)
        {
            var response = new BaseResponseModel();
            var isCategoriesExist = _unitOfWork.Categories.Exists(c => c.Id == categoriesId && !c.IsDeleted);

            if (!isCategoriesExist)
            {
                response.Message = "Categories does not exist.";
                return response;
            }

            var categories = _unitOfWork.Categories.Get(categoriesId);
            categories.IsDeleted = true;

            try
            {
                _unitOfWork.Categories.Update(categories);
                _unitOfWork.SaveChanges();
                response.Status = true;
                response.Message = "Categories successfully deleted.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Can not delete categories: {ex.Message}";
                return response;
            }
        }

        public CategoriessResponseModel GetAllCategories()
        {
            var response = new CategoriessResponseModel();

            try
            {
                Expression<Func<Categories, bool>> expression = c => c.IsDeleted == false;
                var categories = _unitOfWork.Categories.GetAll(expression);

                if (categories is null || categories.Count == 0)
                {
                    response.Message = "No categories found!";
                    return response;
                }

                response.Data = categories.Select(
                    categories => new CategoriesViewModel
                    {
                        Id = categories.Id,
                        Name = categories.Name,
                        Description = categories.Description
                    }).ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }

            response.Status = true;
            response.Message = "Success";

            return response;
        }

        public CategoriesResponseModel GetCategories(string categoriesId)
        {
            var response = new CategoriesResponseModel();

            Expression<Func<Categories, bool>> expression = c =>
                                                (c.Id == categoriesId)
                                                && (c.Id == categoriesId
                                                && c.IsDeleted == false);

            var categoriesExist = _unitOfWork.Categories.Exists(expression);

            if (!categoriesExist)
            {
                response.Message = $"Categories with id {categoriesId} does not exist.";
                return response;
            }

            var categories = _unitOfWork.Categories.Get(categoriesId);

            response.Message = "Success";
            response.Status = true;
            response.Data = new CategoriesViewModel
            {
                Id = categories.Id,
                Name = categories.Name,
                Description = categories.Description
            };

            return response;
        }

        public BaseResponseModel UpdateCategories(string categoriesId, UpdateCategoriesViewModel request)
        {
            var response = new BaseResponseModel();
            string modifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            var categoriesExist = _unitOfWork.Categories.Exists(c => c.Id == categoriesId);

            if (!categoriesExist)
            {
                response.Message = "Categories does not exist.";
                return response;
            }

            var categories = _unitOfWork.Categories.Get(categoriesId);
            categories.Description = request.Description;
            categories.ModifiedBy = modifiedBy;

            try
            {
                _unitOfWork.Categories.Update(categories);
                _unitOfWork.SaveChanges();
                response.Message = "Categories updated successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Could not update the categories: {ex.Message}";
                return response;
            }
        }

        public IEnumerable<SelectListItem> SelectCategories()
        {
            return _unitOfWork.Categories.SelectAll().Select(cat => new SelectListItem()
            {
                Text = cat.Name,
                Value = cat.Id
            });
        }
    }
}