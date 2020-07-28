using CatalogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Queries.Aggregates.Repository
{
    public interface IProductQueriesRepository
    {
        Task<IList<Product>> GetProducts();
    }
}
