using CatalogApi.Domain.Aggregates.Events;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Entities
{
    public class Category : Entity
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }

        public Category(string name, 
            string image, 
            List<SubCategory> subCategories) : base()
        {
            Name = name;
            Image = image;
            SubCategories = subCategories;
            this.Status = "A";
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = this.CreatedAt;
            RaiseEvent(new CreateEvent<Category>("Category.Create", this));
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public List<SubCategory> SubCategories { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal void Update(string name, 
                             string image,
                             List<SubCategory> subCategories)
        {
            this.Name = name;
            this.Image = image;
            this.SubCategories = subCategories;
            this.UpdatedAt = DateTime.Now;

            RaiseEvent(new UpdateEvent<Category>("Category.Update", this));
        }

        internal void Delete()
        {
            this.UpdatedAt = DateTime.Now;
            this.Status = "I";

            RaiseEvent(new DeleteEvent<Category>("Category.Delete", this));
        }
    }
}

