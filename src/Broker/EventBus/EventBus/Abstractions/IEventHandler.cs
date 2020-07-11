using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeekManiaMicroservices.Broker.EventBus.Abstractions
{
    public interface IEventHandler<in TIEvent> : IEventHandler
        where TIEvent : IEvent
    {
        Task Handle(TIEvent @event);
    }

    public interface IEventHandler
    {
    }
}
