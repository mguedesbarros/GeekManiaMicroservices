using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events
{
    public class UpdateCategoryEvent : Event<Category>
    {
        public UpdateCategoryEvent(Category eventData) : base("Category.Update", eventData)
        {
        }
    }
}
