using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.EventBus
{
    public class RabbitSubscribe : BackgroundService
    {
        private readonly IRabbitConnection _rabbitConnection;

        public RabbitSubscribe(IRabbitConnection rabbitConnection)
        {
            _rabbitConnection = rabbitConnection;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = _rabbitConnection.GetModel();
            channel.QueueDeclare(queue: _rabbitConnection.GetQueueName(),
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queue: _rabbitConnection.GetQueueName(),
                 autoAck: true,
                 consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }

        private static void Consumer_Received(
            object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(Environment.NewLine +
                "[Nova mensagem recebida] " + message);
        }
    }
}
