using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace CatalogApi.Domain.Entities
{
    public class Product : Entity
    {
        public Product()
        {
            //Images = new List<string>();
        }

        public Product(string name, string description, decimal unityPrice, int quantity, int? quantityInStock, string image, int categoryId, int? subCategoryId, int? noveltyId)
        {
            ValidateName(name);
            ValidateDescription(description);

            Name = name;
            Description = description;
            UnityPrice = unityPrice;
            Quantity = quantity;
            QuantityInStock = quantityInStock;
            Image = image;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            NoveltyId = noveltyId;
            //Images = images;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal UnityPrice { get; private set; }
        public int Quantity { get; private set; }
        public int? QuantityInStock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; private set; }
        public int? SubCategoryId { get; private set; }
        public int? NoveltyId { get; private set; }
        //public List<string> Images { get; private set; }

        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be white or null");
        }

        public void ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("Description cannot be white or null");
        }
    }
}
