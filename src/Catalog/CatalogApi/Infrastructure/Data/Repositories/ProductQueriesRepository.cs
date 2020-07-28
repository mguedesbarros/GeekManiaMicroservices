using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Queries.Aggregates.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data.Repositories
{
    public class ProductQueriesRepository : IProductQueriesRepository
    {
        private CatalogContext _context;
        private DbSet<Product> _dbSet;

        public ProductQueriesRepository(CatalogContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }
        public async Task<IList<Product>> GetProducts()
        {
            await _context.ProductImage.ToListAsync();
            var products = await _dbSet.ToListAsync();

            return products;
        }
    }
}
