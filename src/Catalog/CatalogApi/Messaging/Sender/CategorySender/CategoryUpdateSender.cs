using CatalogApi.Domain.Entities;
using CatalogApi.Messaging.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApi.Messaging.Sender.CategorySender
{
    public class CategoryUpdateSender : ICategoryUpdateSender
    {
        private readonly string _hostname;
        private readonly int _port;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public CategoryUpdateSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _port = rabbitMqOptions.Value.Port;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
        }

        public void SendCategory(Category category)
        {
            var factory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password, Port = _port };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var json = JsonConvert.SerializeObject(category);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            }
        }
    }
}
