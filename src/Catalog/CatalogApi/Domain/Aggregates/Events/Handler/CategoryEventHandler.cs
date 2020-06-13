using CatalogApi.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Handler
{
    public class CategoryEventHandler :
        INotificationHandler<CreateCategoryEvent>,
        INotificationHandler<UpdateCategoryEvent>,
        INotificationHandler<DeleteCategoryEvent>
    {
        private readonly IEventBus _eventBus;

        public CategoryEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(UpdateCategoryEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(CreateCategoryEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(DeleteCategoryEvent notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
