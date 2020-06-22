using CatalogApiReading.Infrastructure.EventBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApiReading.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services
               .AddTransient<IRabbitConnection, RabbitConnection>();

            return services;
        }
    }
}
