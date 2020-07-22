using CatalogApiReading.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.CategoryProduct
{
    public class CategoryProductRepository : ICategoryProductRepository
    {
        protected readonly ICatalogContext Context;
        protected IMongoCollection<Models.CategoryProduct> DbSet;

        public CategoryProductRepository(ICatalogContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<Models.CategoryProduct>(typeof(Models.CategoryProduct).Name);
        }
        public void Add(Models.CategoryProduct categoryProduct)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(categoryProduct));
        }

        public void BulkInsert(IEnumerable<WriteModel<Models.CategoryProduct>> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.CategoryProduct>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<Models.CategoryProduct>.Filter.Empty);
            return all.ToList();
        }

        public Task<IList<Models.CategoryProduct>> GetByFilter(FilterDefinition<Models.CategoryProduct> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.CategoryProduct> GetCategoryProductsByDocumentId(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<Models.CategoryProduct>.Filter.Eq("_id", id));

            return data.SingleOrDefault();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.CategoryProduct categoryProduct)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<Models.CategoryProduct>.Filter.Eq("_id", categoryProduct.Id), categoryProduct));
        }
    }
}
