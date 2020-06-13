using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.EventBus
{
    public interface IRabbitConnection
    {
        IModel GetModel();
        string GetExchange();
        string GetRoutingKey();
        string GetQueueName();
    }
}
