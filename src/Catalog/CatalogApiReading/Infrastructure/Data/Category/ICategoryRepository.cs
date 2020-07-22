using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Category
{
    public interface ICategoryRepository
    {
        void Add(Models.Category category);
        Task<IEnumerable<Models.Category>> GetAll();
        void Update(Models.Category category);
        void Remove(Guid id);
        Task<IList<Models.Category>> GetByFilter(FilterDefinition<Models.Category> filter);
        void BulkInsert(IEnumerable<WriteModel<Models.Category>> entities);
        Task<IEnumerable<Models.Category>> GetProductsByDocumentId(Guid id);
    }
}
