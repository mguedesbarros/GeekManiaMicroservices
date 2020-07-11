using CatalogApi.Domain.Aggregates.Commands.Product;
using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Repositories;
using CatalogApi.Domain.SeedWork;
using CatalogApi.IntegrationEvents.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Handlers
{
    public class ProductCommandHandler : CommandHandler<Product>,
        IRequestHandler<CreateProductCommand, CommandResult<Product>>,
        IRequestHandler<UpdateProductCommand, CommandResult<Product>>,
        IRequestHandler<DeleteProductCommand, CommandResult<Product>>
    {
        private readonly IProductRepository _repository;
        private GeekManiaMicroservices.Broker.EventBus.Abstractions.IEventBus _eventBus;
        public ProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork, GeekManiaMicroservices.Broker.EventBus.Abstractions.IEventBus eventBus) : base(unitOfWork)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task<CommandResult<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindOneAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));

            if (product != null)
                return CommandResult<Product>.Fail(product, "Product already exists");

            product = new Product(request.Name, 
                request.Description,
                request.UnityPrice, 
                request.QuantityInStock, 
                request.Image, 
                request.CategoryId, 
                request.SubCategoryId, 
                request.NoveltyId, 
                request.Images);            

            _repository.Create(product);

            //var productEvent = new ProductIntegrationEvent(product.Name,
            //   product.Description,
            //   product.UnityPrice,
            //   product.QuantityInStock,
            //   product.Image,
            //   product.CategoryId,
            //   product.SubCategoryId,
            //   product.NoveltyId,
            //   product.Images.Select(s => ProductImage.CreateModel(s)).ToList(),
            //   product.Status,
            //   product.CreatedAt,
            //   product.UpdatedAt);

            PublishEvents(product);
            return CommandResult<Product>.Success(product);
        }

        public async Task<CommandResult<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            if (product == null)
                return CommandResult<Product>.Fail(product, "Product not exists ");

            product.Update(request.Name,
                request.Description,
                request.UnityPrice,
                request.QuantityInStock,
                request.Image,
                request.CategoryId,
                request.SubCategoryId,
                request.NoveltyId,
                request.Images);

            _repository.Update(product);

            PublishEvents(product);
            return CommandResult<Product>.Success(product);
        }

        public async Task<CommandResult<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            if (product == null)
                return CommandResult<Product>.Fail(product, "Product not exists ");

            product.Delete();
            _repository.Delete(product);

            PublishEvents(product);

            return CommandResult<Product>.Success(product);

        }
    }
}
