using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Models
{
    public class Image : Entity
    {
        public Image() { }

        [JsonProperty("url")]
        public string  Url{ get; set; }

        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }
    }
}
