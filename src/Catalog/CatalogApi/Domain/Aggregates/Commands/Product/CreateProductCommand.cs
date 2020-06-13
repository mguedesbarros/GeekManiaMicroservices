using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogApi.Domain.Aggregates.Commands.Product
{
    public class CreateProductCommand : ICommand<CommandResult<Entities.Product>>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal UnityPrice { get; private set; }
        public int Quantity { get; private set; }
        public int? QuantityInStock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; private set; }
        public int? SubCategoryId { get; private set; }
        public int? NoveltyId { get; private set; }
    }
}
