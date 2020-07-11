using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork
{
    public abstract class CommandHandler<TEntity> 
        where TEntity : Entity

    {
        private readonly IUnitOfWork _unitOfWork;

        protected CommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected void PublishEvents(TEntity entity) => _unitOfWork.AddEvents(entity.Events);
    }
}
