using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.Category;
using CatalogApiReading.Infrastructure.Data.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.UoW;
using CatalogApiReading.IntegrationEvent.Events;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.EventHandling
{
    public class CategoryCreateEventHandler : IEventHandler<CategoryCreateEvent>
    {
        private readonly ICategoryProductRedisRepository _categoryProductRedisRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly ICategoryRedisRepository _categoryRedisRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateEventHandler(ICategoryProductRedisRepository categoryProductRedisRepository, 
                                          ICategoryProductRepository categoryProductRepository,
                                          ICategoryRedisRepository categoryRedisRepository,
                                          IUnitOfWork unitOfWork)
        {
            _categoryProductRedisRepository = categoryProductRedisRepository;
            _categoryProductRepository = categoryProductRepository;
            _categoryRedisRepository = categoryRedisRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CategoryCreateEvent @event)
        {
            try
            {
                var categoryEvent = @event.CategoryEvent;

                var categoryProduct = new CategoryProduct(categoryEvent.Id, categoryEvent.Name, categoryEvent.Image, categoryEvent.CreatedAt);

                var result = await _categoryProductRepository.GetCategoryProductsByDocumentId(categoryEvent.Id);
                
                if (result == null)
                {
                    _categoryProductRepository.Add(categoryProduct);

                    await _unitOfWork.Commit();

                    var categoryProducts = await _categoryProductRepository.GetAll();

                    var categories = categoryProducts.GroupBy(g => g.Name)
                                                     .Select(s => new Category
                                                     {
                                                         Id = s.FirstOrDefault().Id,
                                                         Name = s.FirstOrDefault().Name
                                                     }).ToList();

                    //if (categories.Any())
                    //    _categoryRedisRepository.Delete();                    

                    //_categoryRedisRepository.Add(categories);                   

                }                
            }
            catch(Exception ex)
            {
                
            }   
        }
    }
}
