using CatalogApiReading.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data
{
    public class CategoryProductRepository : ICategoryProdutoRepository
    {
        protected readonly ICatalogContext Context;
        protected IMongoCollection<CategoryProduct> DbSet;

        public CategoryProductRepository(ICatalogContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<CategoryProduct>(typeof(CategoryProduct).Name);
        }
        public void Add(CategoryProduct categoryProduct)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(categoryProduct));
        }

        public void BulkInsert(IEnumerable<WriteModel<CategoryProduct>> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryProduct>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<CategoryProduct>> GetByFilter(FilterDefinition<CategoryProduct> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryProduct>> GetCategoryProductsByDocumentId(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<CategoryProduct>.Filter.Eq("_id", id));

            return data.ToList();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryProduct categoryProduct)
        {
            throw new NotImplementedException();
        }
    }
}
