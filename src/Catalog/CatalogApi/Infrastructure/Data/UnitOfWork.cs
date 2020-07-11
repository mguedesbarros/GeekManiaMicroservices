using CatalogApi.Domain.SeedWork;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _catalogContext;
        private readonly IEventBus _eventBus;
        private List<IEvent> _events;

        public UnitOfWork(CatalogContext catalogContext, IEventBus eventBus)
        {
            _catalogContext = catalogContext;
            _eventBus = eventBus;
            _events = new List<IEvent>();
        }

        public void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }

        public void AddEvents(IReadOnlyCollection<IEvent> events)
        {
            _events.AddRange(events);
        }


        public void Commit()
        {
            _catalogContext.SaveChanges();
            _eventBus.AddEvents(_events);
        }

        public IDbConnection DbConnection() => _catalogContext.GetConnection();
    }
}
