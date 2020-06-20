using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogApi.Domain.Aggregates.Commands.Category
{
    public class DeleteCategoryCommand : ICommand<CommandResult<Entities.Category>>
    {
        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
