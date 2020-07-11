using CatalogApi.Domain.SeedWork;
using eekManiaMicroservices.Broker.EventBus.Abstractions;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
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

        public void Publish(IEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void SubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            throw new NotImplementedException();
        }
    }
}
