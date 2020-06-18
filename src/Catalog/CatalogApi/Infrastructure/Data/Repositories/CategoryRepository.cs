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
    }
}
