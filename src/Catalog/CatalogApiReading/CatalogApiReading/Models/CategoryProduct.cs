using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Models
{
    public partial class CategoryProduct : Entity
    {
        public CategoryProduct(Guid id, string name, string image, DateTime createdAt) 
        {
            Id = id;
            Name = name;
            Image = image;
            Status = "A";
            Products = new List<Product>();
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("products")]
        public List<Product> Products { get; private set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; private set; }
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; private set; }
    }

    public partial class CategoryProduct
    {
        public static CategoryProduct FromJson(string json) => JsonConvert.DeserializeObject<CategoryProduct>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CategoryProduct self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
