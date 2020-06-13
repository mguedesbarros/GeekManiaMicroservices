using CatalogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Queries.Aggregates.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
