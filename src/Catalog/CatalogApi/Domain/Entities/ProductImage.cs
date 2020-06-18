using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Entities
{
    public class ProductImage : Entity
    {
        public string Image { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
