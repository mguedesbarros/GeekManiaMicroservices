using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Category
{
    public class CategoryCreateEvent : Event<Entities.Category>
    {
        public CategoryCreateEvent(string eventType, Entities.Category eventData) : base(eventType, eventData)
        {
        }
    }
}
