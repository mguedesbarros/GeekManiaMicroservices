using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Entities
{
    public class SubCategory : Entity
    {
        public SubCategory() { }
        public SubCategory(string name, string image, int categoryId)
        {
            ValidateName(name);
            ValidateCategoryId(categoryId);

            Name = name;
            Image = image;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        public SubCategory Update(string name, string image, int categoryId)
        {
            ValidateName(name);
            ValidateCategoryId(categoryId);

            Name = name;
            Image = image;
            CategoryId = categoryId;

            return this;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be white or null");
        }

        private void ValidateCategoryId(int categoryId)
        {
            if (categoryId == null)
                throw new Exception("Guid cannot be null");
        }
    }
}
