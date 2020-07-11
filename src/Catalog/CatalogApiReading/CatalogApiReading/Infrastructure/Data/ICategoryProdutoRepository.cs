using CatalogApiReading.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data
{
    public interface ICategoryProdutoRepository
    {
        void Add(CategoryProduct categoryProduct);
        Task<IEnumerable<CategoryProduct>> GetAll();
        void Update(CategoryProduct categoryProduct);
        void Remove(Guid id);
        Task<IList<CategoryProduct>> GetByFilter(FilterDefinition<CategoryProduct> filter);
        void BulkInsert(IEnumerable<WriteModel<CategoryProduct>> entities);
        Task<IEnumerable<CategoryProduct>> GetCategoryProductsByDocumentId(Guid id);
    }
}
