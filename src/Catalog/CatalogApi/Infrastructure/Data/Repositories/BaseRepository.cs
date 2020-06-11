using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<T> where T : Entity
    {
        protected readonly CatalogContext context;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly DbSet<T> DbSet;

        protected BaseRepository(CatalogContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            DbSet = context.Set<T>();
        }
    }
}
