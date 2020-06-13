using AutoMapper;
using CatalogApi.Application.Models.Category;
using CatalogApi.Application.Services.Interfaces;
using CatalogApi.Domain.Aggregates.Commands.Category;
using CatalogApi.Domain.Queries.Aggregates.Models;
using CatalogApi.Domain.Queries.Aggregates.Repository;
using CatalogApi.Domain.SeedWork;
using CatalogApi.Infrastructure.Mapper;
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
        private readonly ICategoryQueriesRepository _queriesRepository;

        public CategoryAppService(IMediator mediator, 
                                  IUnitOfWork uow, 
                                  ICategoryQueriesRepository queriesRepository)
        {
            _mediator = mediator;
            _uow = uow;
            _queriesRepository = queriesRepository;
        }

        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            var command = request.ProjectedAs<CreateCategoryCommand>();
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreateCategoryResponse>();
        }

        public async Task<IList<CategoryModel>> GetCategories()
        {
            var result = await _queriesRepository.GetCategories();

            return result.ProjectedAs<IList<CategoryModel>>();
        }

        public async Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request)
        {
            var command = request.ProjectedAs<UpdateCategoryCommand>();
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<UpdateCategoryResponse>();
        }

        public async Task<DeleteCategoryResponse> DeleteAsync(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<DeleteCategoryResponse>();
        }
    }
}
