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
        }

        public Category(string name, string image) : base()
        {
            Name = name;
            Image = image;
            this.Status = "A";
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = this.CreatedAt;
            RaiseEvent(new CreateEvent<Category>("Category.Create", this));
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public List<SubCategory> SubCategory { get; private set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal void Update(string name, string image)
        {
            this.Name = name;
            this.Image = image;
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

