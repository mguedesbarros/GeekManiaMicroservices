using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekManiaMicroservices.Broker.EventBus.Abstractions
{
    public interface IEvent : INotification
    {
        object GetEventData();
        string GetEventType();
    }
}
