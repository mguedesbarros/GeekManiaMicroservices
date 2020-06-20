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
        protected CatalogContext _context;
        protected DbSet<Category> dbSet;

        public CategoryRepository(CatalogContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            dbSet = _context.Set<Category>();
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            await _context.SubCategory.ToListAsync();
            return await dbSet.FindAsync(id);
        }
    }
}
