using CatalogApi.Application.Services;
using CatalogApi.Application.Services.Interfaces;
using CatalogApi.Domain.Queries.Aggregates.Repository;
using CatalogApi.Domain.Repositories;
using CatalogApi.Infrastructure.Data;
using CatalogApi.Infrastructure.Data.Repositories;
using CatalogApi.Infrastructure.EventBus;
using CatalogApi.Infrastructure.Mapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using GeekManiaMicroservices.Broker.EventBusRabbitMQ;
using GeekManiaMicroservices.Broker.EventBus;
using CatalogApi.Domain.SeedWork;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;

namespace CatalogApi.Infrastructure.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddSingleton<ITypeAdapterFactory, AutoMapperTypeAdapterFactory>()
               .AddSingleton<ITypeAdapter, AutoMapperTypeAdapter>()
               .AddSingleton<IEventBus, RabbitEventBus>()
               .AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>()
               .AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
               {
                   var subscriptionClientName = configuration["SubscriptionClientName"];
                   var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                   var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                   var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                   var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                   var retryCount = 5;
                   if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                   {
                       retryCount = int.Parse(configuration["EventBusRetryCount"]);
                   }

                   return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, scopeFactory, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
               })
               .AddTransient<IRabbitConnection, RabbitConnection>()
               .AddSingleton<IRabbitMQPersistentConnection>(sp =>
               {
                   var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                   var factory = new ConnectionFactory()
                   {
                       HostName = configuration["EventBusConnection"],
                       Port = int.Parse(configuration["EventBusPort"]),
                       DispatchConsumersAsync = true
                       
                   };

                   if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
                   {
                       factory.UserName = configuration["EventBusUserName"];
                   }

                   if (!string.IsNullOrEmpty(configuration["EventBusPassword"]))
                   {
                       factory.Password = configuration["EventBusPassword"];
                   }

                   var retryCount = 5;
                   if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                   {
                       retryCount = int.Parse(configuration["EventBusRetryCount"]);
                   }

                   return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
               }
               )
               .AddScoped<IUnitOfWork, UnitOfWork>()
               .AddDbContext<CatalogContext>()
               .AddTransient<ICategoryRepository, CategoryRepository>()
               .AddTransient<ICategoryQueriesRepository, CategoryQueriesRepository>()
               .AddTransient<ICategoryAppService, CategoryAppService>()
               .AddTransient<IProductRepository, ProductRepository>()
               //.AddTransient<IProductQueriesRepository, ProductQueriesRepository>()
               .AddTransient<IProductAppService, ProductAppService>();

            services.AddMediatR(typeof(Entity));

            var sp = services.BuildServiceProvider();

            TypeAdapterFactory.SetCurrent(sp.GetService<ITypeAdapterFactory>());

            return services;
        }
    }
}
