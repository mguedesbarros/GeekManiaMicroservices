using CatalogApi.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CatalogApi.Application.Models.Product
{
    public class CreateProductRequest
    {
        public CreateProductRequest()
        {
            Images = new List<ProductImageModel>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [JsonProperty("unityPrice")]
        public decimal UnityPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [JsonProperty("quantityInStock")]
        public int QuantityInStock { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }
        [JsonProperty("subCategoryId")]
        public Guid? SubCategoryId { get; set; }
        [JsonProperty("noveltyId")]
        public Guid? NoveltyId { get; set; }
        [Required]
        public List<ProductImageModel> Images { get; set; }

    }
}
