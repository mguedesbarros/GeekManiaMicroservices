using CatalogApiReading.Infrastructure.Data.Caching;
using CatalogApiReading.Infrastructure.Data.Caching.Base;
using CatalogApiReading.Infrastructure.Data.Caching.CategoryProduct;
using CatalogApiReading.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.CategoryProduct
{
    public class CategoryProductRedisRepository : BaseRedisRepository, ICategoryProductRedisRepository
    {
        //private readonly IDistributedCache _cache;
        //public CategoryProductRedisRepository(IDistributedCache cache)
        //{
        //    _cache = cache;
        //}

        //public void Add(Models.CategoryProduct categoryProduct)
        //{
        //    string serializeObject = JsonConvert.SerializeObject(categoryProduct);
        //    byte[] data = Encoding.UTF8.GetBytes(serializeObject);

        //    var key = $"categoryProduct-{categoryProduct.Id}";

        //    _cache.Set(key, data);
        //}

        //public void Delete(Guid documentId)
        //{
        //    var key = $"categoryProduct-{documentId}";

        //    _cache.Remove(key);
        //}

        //public async Task<Models.CategoryProduct> Get()
        //{
        //    Models.CategoryProduct categoryProduct = new Models.CategoryProduct();

        //    byte[] data = await _cache.GetAsync("CategoryProduct");

        //    if (data != null)
        //    {
        //        var json = Encoding.UTF8.GetString(data);

        //        categoryProduct = JsonConvert.DeserializeObject<Models.CategoryProduct>(json);
        //    }

        //    return categoryProduct;
        //}

        //public async Task<Models.CategoryProduct> GetCategoryProductsByDocumentId(Guid IdCategoria)
        //{
        //    var categoryProduct = new Models.CategoryProduct();
        //    var key = $"categoryProduct-{IdCategoria}";

        //    byte[] data = await _cache.GetAsync(key);

        //    if (data != null)
        //    {
        //        var json = Encoding.UTF8.GetString(data);

        //        categoryProduct = JsonConvert.DeserializeObject<Models.CategoryProduct>(json);
        //    }

        //    return categoryProduct;
        //}
        public CategoryProductRedisRepository(ICatalogRedisContext context) : base(context)
        {
        }
    }
}
