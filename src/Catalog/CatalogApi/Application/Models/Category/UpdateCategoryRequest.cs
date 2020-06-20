using CatalogApi.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Models.Category
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [JsonProperty("subCategories")]
        public List<SubCategory> SubCategories { get; set; }
    }
}
