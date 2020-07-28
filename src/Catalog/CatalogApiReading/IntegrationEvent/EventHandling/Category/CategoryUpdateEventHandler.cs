using CatalogApiReading.Infrastructure.Data.Caching;
using CatalogApiReading.Infrastructure.Data.Caching.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.Category;
using CatalogApiReading.Infrastructure.Data.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.UoW;
using CatalogApiReading.IntegrationEvent.Events.Category;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.EventHandling.Category
{
    public class CategoryUpdateEventHandler : IEventHandler<CategoryUpdateEvent>
    {
        const string KEY_CACHE = "categories";
        private readonly ICategoryProductRedisRepository _categoryProductRedisRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly ICategoryRedisRepository _categoryRedisRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryUpdateEventHandler(ICategoryProductRedisRepository categoryProductRedisRepository,
                                         ICategoryProductRepository categoryProductRepository,
                                         ICategoryRedisRepository categoryRedisRepository,
                                         IUnitOfWork unitOfWork)
        {
            _categoryProductRedisRepository = categoryProductRedisRepository;
            _categoryProductRepository = categoryProductRepository;
            _categoryRedisRepository = categoryRedisRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(CategoryUpdateEvent @event)
        {
            try
            {
                var categoryEvent = @event.CategoryEvent;

                var categoryProduct = new CategoryProduct();

                categoryProduct.Update(categoryEvent.Id, categoryEvent.Name, categoryEvent.Image, categoryEvent.Status);

                var result = await _categoryProductRepository.GetCategoryProductsByDocumentId(categoryEvent.Id);

                if (result != null)
                {
                    _categoryProductRepository.Update(categoryProduct);

                    await _unitOfWork.Commit();

                    var categoryProducts = await _categoryProductRepository.GetAll();

                    var categories = categoryProducts.Where(x => x.Status == "A")
                                                     .GroupBy(g => g.Name)
                                                     .Select(s => new CategoryResponse
                                                     {
                                                         Id = s.FirstOrDefault().Id,
                                                         Name = s.FirstOrDefault().Name,
                                                         Image = s.FirstOrDefault().Image
                                                     }).ToList();

                    _categoryRedisRepository.Remove(KEY_CACHE, (int)RedisBase.Category);
                    _categoryRedisRepository.Set(KEY_CACHE, categories, (int)RedisBase.Category);

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
