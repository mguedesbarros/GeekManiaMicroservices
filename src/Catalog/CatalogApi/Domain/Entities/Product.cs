using CatalogApi.Domain.Aggregates.Events;
using CatalogApi.Domain.Aggregates.Events.Product;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace CatalogApi.Domain.Entities
{
    public class Product : Entity
    {
        public Product()
        {
            Images = new List<ProductImage>();
        }

        public Product(string name, 
            string description, 
            decimal unityPrice, 
            int quantityInStock, 
            string image,
            Guid categoryId,
            Guid? subCategoryId,
            Guid? noveltyId,
            List<ProductImage> images)
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

            this.Status = "A";
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = this.CreatedAt;

            RaiseEvent(new ProductCreateEvent("Product.Create", this));
        }

        internal void Update(string name,
            string description,
            decimal unityPrice,
            int quantityInStock,
            string image,
            Guid categoryId,
            Guid? subCategoryId,
            Guid? noveltyId,
            List<ProductImage> images)
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

            this.UpdatedAt = DateTime.Now;

            RaiseEvent(new UpdateEvent<Product>("Product.Update", this));
        }

        internal void Delete()
        {
            this.UpdatedAt = DateTime.Now;
            this.Status = "I";

            RaiseEvent(new DeleteEvent<Product>("Product.Delete", this));
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
        public virtual Category Category { get; set; }

    }
}
