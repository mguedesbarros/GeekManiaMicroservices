using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Queries.Aggregates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Queries.Aggregates.Repository
{
    public interface ICategoryQueriesRepository
    {
        Task<IList<Category>> GetCategories();
    }
}
