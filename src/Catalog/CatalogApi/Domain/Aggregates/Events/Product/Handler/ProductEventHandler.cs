using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Product.Handler
{
    public class ProductEventHandler : INotificationHandler<ProductCreateEvent>
    {
        private readonly IEventBus _eventBus;

        public ProductEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(ProductCreateEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
