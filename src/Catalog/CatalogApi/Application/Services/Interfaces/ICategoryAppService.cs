using CatalogApi.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Services.Interfaces
{
    public interface ICategoryAppService
    {
        Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request);
    }
}
