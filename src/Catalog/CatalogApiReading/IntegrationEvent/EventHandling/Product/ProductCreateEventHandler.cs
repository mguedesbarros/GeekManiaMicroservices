using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.Caching;
using CatalogApiReading.Infrastructure.Data.Caching.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.UoW;
using CatalogApiReading.IntegrationEvent.Events;
using CatalogApiReading.IntegrationEvent.Events.Product;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.EventHandling.Product
{
    public class ProductCreateEventHandler : IEventHandler<ProductCreateEvent>
    {
        const string KEY_CACHE = "categoryProduct";
        private readonly ICategoryProductRedisRepository _categoryProductRedisRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly IUnitOfWork _uow;

        public ProductCreateEventHandler(ICategoryProductRedisRepository categoryProductRedisRepository,
                                         ICategoryProductRepository categoryProductRepository,
                                         IUnitOfWork uow)
        {
            _categoryProductRedisRepository = categoryProductRedisRepository;
            _categoryProductRepository = categoryProductRepository;
            _uow = uow;
        }

        public async Task Handle(ProductCreateEvent @event)
        {
            
            var productEvent = @event.ProductEvent;
            var key = $"{KEY_CACHE}-{productEvent.CategoryId}";

            var categoryProduct = await _categoryProductRepository.GetCategoryProductsByDocumentId(productEvent.CategoryId);

            if (categoryProduct != null)
            {
                var productBase = categoryProduct?.Products?.FirstOrDefault(x => x.Id == productEvent.Id);

                if (productBase != null)
                    categoryProduct.Products.Remove(productBase);

                var product = new Models.Product(productEvent.Id,
                        productEvent.Name,
                        productEvent.Description,
                        productEvent.UnityPrice,
                        productEvent.QuantityInStock,
                        productEvent.Images,
                        productEvent.SubCategory,
                        productEvent.Status,
                        productEvent.CreatedAt,
                        productEvent.UpdatedAt);

                categoryProduct.Products.Add(product);
                _categoryProductRepository.Update(categoryProduct);
                await _uow.Commit();

                _categoryProductRedisRepository.Remove(key, (int)RedisBase.Product);

                _categoryProductRedisRepository.Set(key, categoryProduct, (int)RedisBase.Product);

            }
        }
    }
}
