using CatalogApi.Messaging.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.EventBus
{
    public class RabbitConnection : IRabbitConnection
    {
        private readonly object _lock = new object();
        private IConnection _connection = null;
        private readonly IModel _channel = null;
        private string QueueName = string.Empty;
        public RabbitConnection(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            if (_channel == null)
            {
                lock (_lock)
                {
                    if (_channel == null)
                    {

                        var factory = new ConnectionFactory()
                        {
                            HostName = rabbitMqOptions.Value.Hostname,
                            Port = rabbitMqOptions.Value.Port,
                            UserName = rabbitMqOptions.Value.UserName,
                            Password = rabbitMqOptions.Value.Password,
                            AutomaticRecoveryEnabled = true
                        };

                        QueueName = rabbitMqOptions.Value.QueueName;
                        _connection = factory.CreateConnection();
                        _channel = _connection.CreateModel();
                    }
                }
            }
        }
        public string GetExchange()
        {
            return "";
        }

        public IModel GetModel()
        {
            return _channel;
        }

        public string GetRoutingKey()
        {
            return QueueName;
        }
        public string GetQueueName()
        {
            return QueueName;
        }
    }
}
