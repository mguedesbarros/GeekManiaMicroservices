using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Repositories
{
    public interface ICategoryRepository : 
        IBaseRepository<Category>,
        IQueryRepository<Category>
    {
        Task<Category> GetCategoryById(Guid id);
    }
}
