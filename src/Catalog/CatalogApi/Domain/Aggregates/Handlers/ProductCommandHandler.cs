using CatalogApi.Domain.Aggregates.Commands.Product;
using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Repositories;
using CatalogApi.Domain.SeedWork;
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
        public ProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
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
