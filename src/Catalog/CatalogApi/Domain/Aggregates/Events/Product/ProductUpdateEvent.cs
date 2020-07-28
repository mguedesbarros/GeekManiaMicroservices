using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Product
{
    public class ProductUpdateEvent : Event<Entities.Product>
    {
        public ProductUpdateEvent(string eventType, Entities.Product eventData) : base(eventType, eventData)
        {
        }
    }
}
