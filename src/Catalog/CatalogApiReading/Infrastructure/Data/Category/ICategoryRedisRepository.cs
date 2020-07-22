using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.Data.Category
{
    public interface ICategoryRedisRepository
    {
        void Add(IList<Models.Category> categories);
        Task<IList<Models.Category>> GetCategories();
        void Delete();
    }
}
