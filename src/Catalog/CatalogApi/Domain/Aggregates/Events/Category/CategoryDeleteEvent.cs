using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Category
{
    public class CategoryDeleteEvent : Event<Entities.Category>
    {
        public CategoryDeleteEvent(string eventType, Entities.Category eventData) : base(eventType, eventData)
        {
        }
    }
}
