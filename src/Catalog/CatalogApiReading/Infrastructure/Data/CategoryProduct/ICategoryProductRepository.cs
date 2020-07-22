using CatalogApiReading.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.CategoryProduct
{
    public interface ICategoryProductRepository
    {
        void Add(Models.CategoryProduct categoryProduct);
        Task<IEnumerable<Models.CategoryProduct>> GetAll();
        void Update(Models.CategoryProduct categoryProduct);
        void Remove(Guid id);
        Task<IList<Models.CategoryProduct>> GetByFilter(FilterDefinition<Models.CategoryProduct> filter);
        void BulkInsert(IEnumerable<WriteModel<Models.CategoryProduct>> entities);
        Task<Models.CategoryProduct> GetCategoryProductsByDocumentId(Guid id);
    }
}
