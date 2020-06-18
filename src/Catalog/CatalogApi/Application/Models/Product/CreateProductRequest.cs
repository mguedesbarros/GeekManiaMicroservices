﻿using CatalogApi.Domain.Entities;
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
            Images = new List<string>();
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
        public int CategoryId { get; set; }
        [JsonProperty("subCategoryId")]
        public int? SubCategoryId { get; set; }
        [JsonProperty("noveltyId")]
        public int? NoveltyId { get; set; }
        [Required]
        public List<string> Images { get; set; }

    }
}
