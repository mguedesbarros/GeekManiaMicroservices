using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork
{
    public abstract class Event<T> : IEvent
    {
        protected Event(string eventType, T eventData)
        {
            this.CreatedAt = DateTime.Now;
            this.EventType = eventType;
            this.EventData = eventData;
        }

        public DateTime CreatedAt { get; set; }
        public string EventType { get; private set; }
        public T EventData { get; private set; }
        public object GetEventData() => this.EventData;
        public string GetEventType() => this.EventType;
    }

    public interface IEvent : INotification
    {
        object GetEventData();
        string GetEventType();
    }
}
