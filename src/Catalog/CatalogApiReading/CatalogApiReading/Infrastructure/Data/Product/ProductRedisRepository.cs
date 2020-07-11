using CatalogApiReading.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Product
{
    public class ProductRedisRepository : IProducRedisRepository
    {
        private readonly IDistributedCache _cache;
        public ProductRedisRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void Add(Models.Product product)
        {
            string serializeObject = JsonConvert.SerializeObject(product);
            byte[] data = Encoding.UTF8.GetBytes(serializeObject);

            var key = $"product-{product}";

            _cache.Set(key, data);
        }

        public void AddProducts(IList<Models.Product> products, Guid IdCategoria, Guid IdSubCategoria)
        {
            string serializeObject = JsonConvert.SerializeObject(products);
            byte[] data = Encoding.UTF8.GetBytes(serializeObject);

            var key = IdSubCategoria == null ? $"product-{IdCategoria}" : $"product-{IdCategoria}-{IdSubCategoria}";

            _cache.Set(key, data);
        }

        public async Task<Models.Product> Get()
        {
            Models.Product product = new Models.Product();

            byte[] data = await _cache.GetAsync("Product");

            if (data != null)
            {
                var json = Encoding.UTF8.GetString(data);

                product = JsonConvert.DeserializeObject<Models.Product>(json);
            }            

            return product;
        }

        public async Task<IList<Models.Product>> GetProducts(Guid IdCategoria, Guid? IdSubCategoria = null)
        {
            var products = new List<Models.Product>();
            var key = IdSubCategoria == null ? $"product-{IdCategoria}" : $"product-{IdCategoria}-{IdSubCategoria}";

            byte[] data = await _cache.GetAsync(key);

            if (data != null)
            {
                var json = Encoding.UTF8.GetString(data);

                products = JsonConvert.DeserializeObject<List<Models.Product>>(json);
            }                       

            return products;
        }       
    }
}
