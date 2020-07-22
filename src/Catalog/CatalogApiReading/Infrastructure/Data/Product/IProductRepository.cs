using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Product
{
    public interface IProductRepository
    {
        void Add(Models.Product product);
        Task<IEnumerable<Models.Product>> GetAll();
        void Update(Models.Product product);
        void Remove(Guid id);
        Task<IList<Models.Product>> GetByFilter(FilterDefinition<Models.Product> filter);
        void BulkInsert(IEnumerable<WriteModel<Models.Product>> entities);
        Task<IEnumerable<Models.Product>> GetProductsByDocumentId(Guid id);
    }
}
