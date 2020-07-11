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
       
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("unityPrice")]
        public long UnityPrice { get; set; }

        [JsonProperty("quantityInStock")]
        public long QuantityInStock { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("subCategory")]
        public SubCategory SubCategory { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }

    public partial class Product
    {
        public static Product FromJson(string json) => JsonConvert.DeserializeObject<Product>(json, Converter.Settings);
    }    
}
