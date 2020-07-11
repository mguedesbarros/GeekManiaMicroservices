using eekManiaMicroservices.Broker.EventBus.Abstractions;
using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekManiaMicroservices.Broker.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IEvent @event);

        void Subscribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>;

        void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IEventHandler<T>
            where T : IEvent;

        void AddEvent(IEvent @event);
        void AddEvents(IReadOnlyCollection<IEvent> events);
    }
}
