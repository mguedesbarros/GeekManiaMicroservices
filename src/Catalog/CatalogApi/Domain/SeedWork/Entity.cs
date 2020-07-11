using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork
{
    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
            this._events = new List<IEvent>();
            this.Key = Guid.NewGuid();
        }

        private readonly List<IEvent> _events;
        public Guid Id { get; private set; }
        public Guid Key { get; private set; }
        public IReadOnlyCollection<IEvent> Events => this._events;
        protected void RaiseEvent(IEvent @event) =>  _events.Add(@event);        
        public void ClearEvents() => _events.Clear();
    }
}
