using CatalogApi.Application.Models.Category;
using CatalogApi.Domain.Queries.Aggregates.Models;
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
        Task<DeleteCategoryResponse> DeleteAsync(Guid id);
        Task<IList<CategoryModel>> GetCategories();
    }
}
