using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.Events.Category
{
    public class CategoryCreateEvent : Event<CategoryEvent>
    {
        public CategoryCreateEvent(string eventType, CategoryEvent eventData) : base(eventType, eventData)
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

    public class CategoryEvent
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
