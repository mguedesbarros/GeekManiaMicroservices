using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events
{
    public class CreateEvent<T> : Event<T>
    {
        public CreateEvent(string eventType, T eventData) : base(eventType, eventData)
        {
        }
    }
}
