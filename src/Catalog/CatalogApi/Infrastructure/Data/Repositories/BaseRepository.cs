using CatalogApi.Domain.SeedWork;
using CatalogApi.Domain.SeedWork.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly CatalogContext context;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(CatalogContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            DbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            DbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> set = DbSet;
            return set.FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entity)
        {
            var _entity = this.context.Entry(entity);
            _entity.State = EntityState.Modified;

            DbSet.Update(entity);
        }
    }
}
