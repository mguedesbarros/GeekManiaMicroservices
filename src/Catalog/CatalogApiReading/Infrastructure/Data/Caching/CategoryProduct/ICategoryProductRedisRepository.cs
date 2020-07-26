using CatalogApiReading.Infrastructure.Data.Caching.Base;
using CatalogApiReading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Caching.CategoryProduct
{
    public interface ICategoryProductRedisRepository : IBaseRedisRepository
    {
        //void Add(Models.CategoryProduct categoryProduct);
        //Task<Models.CategoryProduct> Get();
        //Task<Models.CategoryProduct> GetCategoryProductsByDocumentId(Guid IdCategoria);
        //void Delete(Guid documentId);
    }
}
