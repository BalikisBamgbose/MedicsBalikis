using Medics.Models.Category;
using Medics.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medics.Models.Categories;

namespace Medics.Service.Interface
{
    public interface ICategoriesService
    {
        BaseResponseModel CreateCategories(CreateCategoriesViewModel createCategoriesDto);
        BaseResponseModel DeleteCategories(string categoriesId);
        BaseResponseModel UpdateCategories(string categoriesId, UpdateCategoriesViewModel updateCategoriesDto);
        CategoriesResponseModel GetCategories(string categoriesId);
        CategoriessResponseModel GetAllCategories();
        IEnumerable<SelectListItem> SelectCategories();
    }
}