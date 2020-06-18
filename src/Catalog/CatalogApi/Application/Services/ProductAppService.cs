using CatalogApi.Application.Models.Product;
using CatalogApi.Application.Services.Interfaces;
using CatalogApi.Domain.Aggregates.Commands.Product;
using CatalogApi.Domain.SeedWork;
using CatalogApi.Infrastructure.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public ProductAppService(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

        public async Task<CreateProductResponse> CreateAsync(CreateProductRequest request)
        {
            var command = request.ProjectedAs<CreateProductCommand>();
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreateProductResponse>();
        }

        public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request)
        {
            var command = request.ProjectedAs<UpdateProductCommand>();
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<UpdateProductResponse>();
        }

        public async Task<DeleteProductResponse> DeleteAsync(int id)
        {
            var command = new DeleteProductCommand(id);
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<DeleteProductResponse>();
        }
    }
}
