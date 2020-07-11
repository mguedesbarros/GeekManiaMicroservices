using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.Category;
using CatalogApiReading.Infrastructure.Data.UoW;
using CatalogApiReading.IntegrationEvent.Events;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.EventHandling
{
    public class CategoryCreateEventHandler : IEventHandler<CategoryCreateEvent>
    {
        private readonly ICategoryProductRedisRepository _categoryProductRedisRepository;
        private readonly ICategoryProdutoRepository _categoryProdutoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateEventHandler(ICategoryProductRedisRepository categoryProductRedisRepository, 
                                          ICategoryProdutoRepository categoryProdutoRepository,
                                          IUnitOfWork unitOfWork)
        {
            _categoryProductRedisRepository = categoryProductRedisRepository;
            _categoryProdutoRepository = categoryProdutoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CategoryCreateEvent @event)
        {
            try
            {
                var categoryEvent = @event.CategoryEvent;

                var categoryProduct = new CategoryProduct(categoryEvent.Id, categoryEvent.Name, categoryEvent.Image, categoryEvent.CreatedAt);

                _categoryProdutoRepository.Add(categoryProduct);

                await _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                
            }   
        }
    }
}
