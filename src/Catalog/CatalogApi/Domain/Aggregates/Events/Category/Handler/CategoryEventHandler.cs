using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Category.Handler
{
    public class CategoryEventHandler : 
        INotificationHandler<CategoryCreateEvent>,
        INotificationHandler<CategoryUpdateEvent>
    {
        private readonly IEventBus _eventBus;

        public CategoryEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(CategoryCreateEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(CategoryUpdateEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
