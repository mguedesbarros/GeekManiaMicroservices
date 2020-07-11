﻿using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.IntegrationEvent.Events
{
    public class ProductCreateEvent : Event<ProductEvent>
    {
        public ProductCreateEvent(string eventType, ProductEvent eventData) : base(eventType, eventData)
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

    public partial class ProductEvent : Entity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("unity_price")]
        public long UnityPrice { get; set; }

        [JsonProperty("quantity_in_stock")]
        public long QuantityInStock { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("category_id")]
        public Guid CategoryId { get; set; }

        [JsonProperty("sub_category_id")]
        public Guid? SubCategoryId { get; set; }

        [JsonProperty("novelty_id")]
        public Guid? NoveltyId { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("id")]
        public Guid ProductId { get; set; }

        [JsonProperty("key")]
        public Guid Key { get; set; }

        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("$ref")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Ref { get; set; }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

}
