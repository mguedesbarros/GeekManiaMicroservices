using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Repositories;
using CatalogApi.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        protected CatalogContext _context;
        protected DbSet<Product> dbSet;
        public ProductRepository(CatalogContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _context = context;
            dbSet = _context.Set<Product>();
        }

        public async Task<Product> GetProductById(int id)
        {
            await _context.ProductImage.ToListAsync();
            return await dbSet.FindAsync(id);

        }
    }
}
