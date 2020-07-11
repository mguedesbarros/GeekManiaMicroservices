using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Models
{
    public class SubCategory :  Entity
    {
        public SubCategory() { }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
