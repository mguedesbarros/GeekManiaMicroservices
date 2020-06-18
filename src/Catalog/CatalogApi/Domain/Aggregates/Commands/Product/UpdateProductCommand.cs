using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogApi.Domain.Aggregates.Commands.Product
{
    public class UpdateProductCommand : ICommand<CommandResult<Entities.Product>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnityPrice { get; set; }
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? NoveltyId { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
