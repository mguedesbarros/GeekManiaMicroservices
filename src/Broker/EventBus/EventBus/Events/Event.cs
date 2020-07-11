using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekManiaMicroservices.Broker.EventBus.Events
{
    public class Event<T> : IEvent
    {
        [JsonConstructor]
        public Event(string eventType, T eventData)
        {
            this.CreationDate = DateTime.Now;
            this.EventType = eventType;
            this.EventData = eventData;
        }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }
        [JsonProperty]
        public string EventType { get; private set; }
        [JsonProperty]
        public T EventData { get; private set; }
        public object GetEventData() => this.EventData;
        public string GetEventType() => this.EventType;
    }
}
