using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Models.Product
{
    public class UpdateProductRequest
    {
        public UpdateProductRequest()
        {
            Images = new List<string>();
        }
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("unityPrice")]
        public decimal UnityPrice { get; set; }
        [JsonProperty("quantityInStock")]
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("subCategoryId")]
        public int? SubCategoryId { get; set; }
        [JsonProperty("noveltyId")]
        public int? NoveltyId { get; set; }
        public List<string> Images { get; set; }
    }
}
