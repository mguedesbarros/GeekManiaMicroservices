using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogApi.Domain.Aggregates.Commands.CategoryCmd
{
    public class UpdateCategoryCommand : ICommand<CommandResult<Category>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
