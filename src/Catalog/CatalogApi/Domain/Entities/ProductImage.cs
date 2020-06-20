using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Entities
{
    public class ProductImage
    {
        public ProductImage() { }
        public Guid Id { get; set; }
        public string Image { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
