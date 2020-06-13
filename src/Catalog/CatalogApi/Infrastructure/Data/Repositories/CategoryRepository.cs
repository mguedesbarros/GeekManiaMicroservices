using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Repositories;
using CatalogApi.Domain.SeedWork;
using CatalogApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public void Add(Category entity)
        {
            DbSet.AddAsync(entity);
        }

        public void Delete(Category entity)
        {
            DbSet.Remove(entity);
        }

        public Task<Category> FindOneAsync(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> set = DbSet;
            return set.FirstOrDefaultAsync(filter);
        }

        public void Update(Category entity)
        {
            DbSet.Update(entity);
        }
    }
}
