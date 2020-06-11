using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events
{
    public class CreateCategoryEvent : Event<Category>
    {
        public CreateCategoryEvent(Category eventData) : base("Category.Created", eventData)
        {
        }
    }
}
