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
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public static ProductImage CreateModel(ProductImage product)
        {
            return new ProductImage
            {
                Id = product.Id,
                Url = product.Url,
                ProductId = product.ProductId
            };
        }
    }
}
