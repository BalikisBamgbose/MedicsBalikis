using Medics.Models.Category;
using Medics.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Medics.Models.Category.CategoryResponseModel;

namespace Medics.Service.Interface
{
    public interface ICategoryService
    {
        BaseResponseModel CreateCategory(CreateCategoryViewModel createCategoryDto);
        BaseResponseModel DeleteCategory(string categoryId);
        BaseResponseModel UpdateCategory(string categoryId, UpdateCategoryViewModel updateCategoryDto);
        CategoryResponseModel GetCategory(string categoryId);
        CategorysResponseModel GetAllCategory();
        IEnumerable<SelectListItem> SelectCategories();
    }
}