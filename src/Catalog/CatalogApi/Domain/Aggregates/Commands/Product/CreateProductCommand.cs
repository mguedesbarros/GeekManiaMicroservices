using CatalogApi.Domain.Entities;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnityPrice { get; set; }
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public Guid? NoveltyId { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
