using CatalogApi.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApi.Domain.Aggregates.Events.Handler
{
    public class EventHandler<T> : 
        INotificationHandler<CreateEvent<T>>,
        INotificationHandler<UpdateEvent<T>>,
        INotificationHandler<DeleteEvent<T>>
    {
        private readonly IEventBus _eventBus;

        public EventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(CreateEvent<T> notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(UpdateEvent<T> notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(DeleteEvent<T> notification, CancellationToken cancellationToken)
        {
            _eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
