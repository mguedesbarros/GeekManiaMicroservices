using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Models.Category category)
        {
            throw new NotImplementedException();
        }

        public void BulkInsert(IEnumerable<WriteModel<Models.Category>> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Models.Category>> GetByFilter(FilterDefinition<Models.Category> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Category>> GetProductsByDocumentId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Category category)
        {
            throw new NotImplementedException();
        }
    }
}
