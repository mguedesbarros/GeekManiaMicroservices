using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Commands.Product
{
    public class DeleteProductCommand : ICommand<CommandResult<Entities.Product>>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
