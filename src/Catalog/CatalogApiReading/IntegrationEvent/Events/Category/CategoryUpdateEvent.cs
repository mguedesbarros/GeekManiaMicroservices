using GeekManiaMicroservices.Broker.EventBus.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.Events.Category
{
    public class CategoryUpdateEvent : Event<CategoryEvent>
    {
        public CategoryUpdateEvent(string eventType, CategoryEvent eventData) : base(eventType, eventData)
        {
        }

        [JsonProperty("$id")]
        public long Id { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_data")]
        public CategoryEvent CategoryEvent { get; set; }
    }    
}
