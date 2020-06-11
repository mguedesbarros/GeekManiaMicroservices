using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork.Repository
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filter);
    }
}
