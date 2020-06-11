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
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = this.CreatedAt;
            RaiseEvent(new CreateCategoryEvent(this));
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public List<SubCategory> SubCategory { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal void Update(string name, string image)
        {
            this.Name = name;
            this.Image = image;
            this.UpdatedAt = DateTime.Now;
            RaiseEvent(new UpdateCategoryEvent(this));
        }

    }
}
