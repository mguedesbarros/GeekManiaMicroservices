using CatalogApi.Domain.Aggregates.Commands.Category;
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
    public class CategoryCommandHandler : CommandHandler<Category>,
        IRequestHandler<CreateCategoryCommand, CommandResult<Category>>,
        IRequestHandler<UpdateCategoryCommand, CommandResult<Category>>,
        IRequestHandler<DeleteCategoryCommand, CommandResult<Category>>
    {
        private readonly ICategoryRepository _repository;
        public CategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task<CommandResult<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.FindOneAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));

            if (category == null)
                return CommandResult<Category>.Fail(category, "Name not exist");

            category.Update(request.Name, request.Image);
            _repository.Update(category);

            PublishEvents(category);
            return CommandResult<Category>.Success(category);
        }

        public async Task<CommandResult<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.FindOneAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));

            if (category != null)
                return CommandResult<Category>.Fail(category, "Name already exists");

            category = new Category(request.Name, request.Image);

            _repository.Add(category);

            PublishEvents(category);
            return CommandResult<Category>.Success(category);
        }

        public async Task<CommandResult<Category>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.FindOneAsync(x => x.Id == request.Id);

            if (category == null)
                return CommandResult<Category>.Fail(category, "Category not exist");

            category.Delete();
            _repository.Update(category);

            PublishEvents(category);
            return CommandResult<Category>.Success(category);
        }
    }
}
