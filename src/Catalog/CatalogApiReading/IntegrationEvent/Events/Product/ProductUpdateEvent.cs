using GeekManiaMicroservices.Broker.EventBus.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.Events.Product
{
    public class ProductUpdateEvent : Event<ProductEvent>
    {
        public ProductUpdateEvent(string eventType, ProductEvent eventData) : base(eventType, eventData)
        {
        }

        [JsonProperty("$id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_data")]
        public ProductEvent ProductEvent { get; set; }
    }
}
