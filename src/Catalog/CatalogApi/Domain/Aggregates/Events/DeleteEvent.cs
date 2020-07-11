using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events
{
    public class DeleteEvent<T> : Event<T>
    {
        public DeleteEvent(string eventType, T eventData) : base(eventType, eventData)
        {
        }
    }
}
