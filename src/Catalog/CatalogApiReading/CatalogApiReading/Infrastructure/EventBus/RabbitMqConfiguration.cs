﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure.EventBus
{
    public class RabbitMqConfiguration
    {
        public string VirtualHost{ get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
