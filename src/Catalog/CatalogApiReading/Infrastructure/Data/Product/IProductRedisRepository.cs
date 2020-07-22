using CatalogApiReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Product
{
    public interface IProductRedisRepository
    {
        void Add(Models.Product product);
        void AddProducts(IList<Models.Product> products, Guid IdCategoria, Guid IdSubCategoria);
        Task<Models.Product> Get();
        Task<IList<Models.Product>> GetProducts(Guid IdCategoria, Guid? IdSubCategoria = null);
    }
}
