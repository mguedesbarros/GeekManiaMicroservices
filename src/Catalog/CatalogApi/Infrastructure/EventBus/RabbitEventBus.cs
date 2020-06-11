using CatalogApi.Domain.SeedWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.EventBus
{
    public class RabbitEventBus : IEventBus
    {
        private readonly IRabbitConnection _rabbitConnection;

        public RabbitEventBus(IRabbitConnection rabbitConnection)
        {
            this._rabbitConnection = rabbitConnection;
        }

        public void AddEvent(IEvent @event)
        {
            var json = Serialize(@event);
            var channel = _rabbitConnection.GetModel();

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: _rabbitConnection.GetExchange(),
                routingKey: _rabbitConnection.GetRoutingKey(),
                basicProperties: properties,
                body: Encoding.UTF8.GetBytes(json)
            );
        }

        public void AddEvents(IReadOnlyCollection<IEvent> events)
        {
            events.ToList().ForEach(p => this.AddEvent(p));
        }
        private string Serialize(IEvent @event) => JsonConvert.SerializeObject(
            value: @event,
            new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });
    }
}
