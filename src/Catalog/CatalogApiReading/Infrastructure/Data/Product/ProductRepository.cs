using CatalogApiReading.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Product
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ICatalogContext Context;
        protected IMongoCollection<Models.Product> DbSet;
        
        public ProductRepository(ICatalogContext context)
        {
            Context = context;
            //Context = context;
            DbSet = Context.GetCollection<Models.Product>(typeof(Models.Product).Name);
        }

        public virtual void Add(Models.Product product)
        {
            //ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(product));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<Models.Product>(typeof(Models.Product).Name);
        }

        public virtual async Task<Models.Product> GetById(Guid id)
        {
            //ConfigDbSet();
            //var bytes = GuidConverter.ToBytes(id, GuidRepresentation.PythonLegacy);
            //var csuuid = new Guid(bytes);

            var data = await DbSet.FindAsync(Builders<Models.Product>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<Models.Product>> GetProductsByDocumentId(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<Models.Product>.Filter.Eq("_id", id));

            return data.ToList();
        }

        public virtual async Task<IEnumerable<Models.Product>> GetAll()
        {
            //ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<Models.Product>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(Models.Product product)
        {
            //ConfigDbSet();
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<Models.Product>.Filter.Eq("_id", product.Id), product));
        }

        public virtual void Remove(Guid id)
        {
            //ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<Models.Product>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public virtual async Task<IList<Models.Product>> GetByFilter(FilterDefinition<Models.Product> filter)
        {
            //ConfigDbSet();
            var data = await DbSet.FindAsync(filter);
            return data.ToList();
        }

        public void BulkInsert(IEnumerable<WriteModel<Models.Product>> entities)
        {
            //ConfigDbSet();
            DbSet.BulkWriteAsync(entities);
        }
    }
}
