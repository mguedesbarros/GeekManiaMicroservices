using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork
{
    public interface IEventBus
    {
        void AddEvent(IEvent @event);
        void AddEvents(IReadOnlyCollection<IEvent> events);
    }
}
