using CatalogApiReading.Infrastructure.Data.Product;
using CatalogApiReading.IntegrationEvent.Events;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.EventHandling
{
    public class ProductCreateEventHandler : IEventHandler<ProductCreateEvent>
    {
        private readonly IProducRedisRepository _productRedisRepository;
        private readonly IProductRepository _productRepository;

        public ProductCreateEventHandler(IProducRedisRepository productRedisRepository, IProductRepository productRepository)
        {
            _productRedisRepository = productRedisRepository;
            _productRepository = productRepository;
        }

        public async Task Handle(ProductCreateEvent @event)
        {
            var product = @event.ProductEvent;

            var products = await _productRepository.GetProductsByDocumentId(product.CategoryId) ;

            if (products.Any())
            {
                var productBase = products.FirstOrDefault<Product>(x => x.Id == product.ProductId);

                if (productBase != null)
                    _productRepository.Update(productBase);
                else
                {

                }

                //FilterDefinition<Product> productFilter = Builders<Product>.Filter.Eq(x => x.Id, product.Id);

                //var _product = await _productRepository.GetByFilter(productFilter);

                
            }

            //_productRedisRepository.Add(product);

        }
    }
}
