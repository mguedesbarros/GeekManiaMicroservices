using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Queries.Aggregates.Models;
using CatalogApi.Domain.Queries.Aggregates.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data.Repositories
{
    public class CategoryQueriesRepository : ICategoryQueriesRepository
    {
        private CatalogContext _context;
        private DbSet<Category> _dbSet;

        public CategoryQueriesRepository(CatalogContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public async Task<IList<Category>> GetCategories()
        {
            await _context.SubCategory.ToListAsync();
            var categories = await _dbSet.ToListAsync();

            return categories;

        }
    }
}
