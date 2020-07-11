using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events
{
    public class UpdateEvent<T> : Event<T>
    {
        public UpdateEvent(string eventType, T eventData) : base(eventType, eventData)
        {
        }
    }
}
