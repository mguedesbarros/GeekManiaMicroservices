using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Commands.Category
{
    public class CreateCategoryCommand : ICommand<CommandResult<Entities.Category>>
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
