using CatalogApi.Domain.Aggregates.Events;
using CatalogApi.Domain.Aggregates.Events.Product;
using CatalogApi.Domain.Entities;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Handlers
{
    public class ProductCreateEventHandler : IEventHandler<ProductCreateEvent>
    {
        public Task Handle(ProductCreateEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
