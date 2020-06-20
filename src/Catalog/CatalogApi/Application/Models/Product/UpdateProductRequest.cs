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
            Images = new List<ProductImageModel>();
        }
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("unityPrice")]
        public decimal UnityPrice { get; set; }
        [JsonProperty("quantityInStock")]
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }
        [JsonProperty("subCategoryId")]
        public Guid? SubCategoryId { get; set; }
        [JsonProperty("noveltyId")]
        public Guid? NoveltyId { get; set; }
        public List<ProductImageModel> Images { get; set; }
    }
}
