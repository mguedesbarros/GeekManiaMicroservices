using CatalogApi.Domain.Entities;
using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.IntegrationEvents.Events
{
    public class ProductIntegrationEvent //: Event
    {
        public ProductIntegrationEvent()
        {
            Images = new List<ProductImage>();
        }
        public ProductIntegrationEvent(string name, 
            string description, 
            decimal unityPrice, 
            int quantityInStock, 
            string image, 
            Guid categoryId, 
            Guid? subCategoryId, 
            Guid? noveltyId, 
            List<ProductImage> images, 
            string status, 
            DateTime createdAt, 
            DateTime updatedAt)
        {
            Name = name;
            Description = description;
            UnityPrice = unityPrice;
            QuantityInStock = quantityInStock;
            Image = image;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            NoveltyId = noveltyId;
            Images = images;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;

        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal UnityPrice { get; private set; }
        public int QuantityInStock { get; private set; }
        public string Image { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid? SubCategoryId { get; private set; }
        public Guid? NoveltyId { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
