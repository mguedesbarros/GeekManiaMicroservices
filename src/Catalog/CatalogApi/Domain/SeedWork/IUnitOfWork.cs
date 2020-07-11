using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using GeekManiaMicroservices.Broker.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        void Commit();
        IDbConnection DbConnection();
        void AddEvent(IEvent @event);
        void AddEvents(IReadOnlyCollection<IEvent> events);
    }
}
