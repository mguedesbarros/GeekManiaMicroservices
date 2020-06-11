using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork.Repository
{
    public interface IUpdateRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }
}
