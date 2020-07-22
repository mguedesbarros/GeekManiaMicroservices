using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Models
{
    public partial class Product : Entity
    {
        public Product() { }

        public Product(Guid id, string name, string description, long unityPrice, long quantityInStock, List<Image> images, SubCategory subCategory, string status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            UnityPrice = unityPrice;
            QuantityInStock = quantityInStock;
            Images = images;
            this.subCategory = subCategory;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("unityPrice")]
        public long UnityPrice { get; private set; }

        [JsonProperty("quantityInStock")]
        public long QuantityInStock { get; private set; }

        [JsonProperty("images")]
        public List<Image> Images { get; private set; }

        [JsonProperty("subCategory")]
        public SubCategory subCategory { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; private set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; private set; }
    }

    public partial class Product
    {
        public static Product FromJson(string json) => JsonConvert.DeserializeObject<Product>(json, Converter.Settings);
    }    
}
