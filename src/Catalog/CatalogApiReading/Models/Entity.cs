using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            //this._events = new List<IEvent>();
            //this.Key = Guid.NewGuid();
        }

        //[JsonProperty("_id")]
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        //public Guid Key { get; private set; }
        //private readonly List<IEvent> _events;
        //public IReadOnlyCollection<IEvent> Events => this._events;
        //protected void RaiseEvent(IEvent @event) => _events.Add(@event);
        //public void ClearEvents() => _events.Clear();
    }
}
