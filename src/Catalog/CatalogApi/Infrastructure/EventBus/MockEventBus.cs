using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.EventBus
{
    public class MockEventBus : IEventBus
    {
        public void AddEvent(IEvent @event)
        {
            Console.WriteLine(@event.GetEventType());

        }

        public void AddEvents(IReadOnlyCollection<IEvent> events)
        {
            events.ToList().ForEach(p => this.AddEvent(p));
        }
    }
}
