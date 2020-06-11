using CatalogApi.Application.Services.Interfaces;
using CatalogApi.Domain.Aggregates.Commands.CategoryCmd;
using CatalogApi.Domain.SeedWork;
using CatalogApi.Infrastructure.Mapper;
using CatalogApi.Models.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public CategoryAppService(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            var command = request.ProjectedAs<CreateCategoryCommand>();
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreateCategoryResponse>();
        }

        public async Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request)
        {
            var command = request.ProjectedAs<UpdateCategoryCommand>();
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<UpdateCategoryResponse>();
        }
    }
}
