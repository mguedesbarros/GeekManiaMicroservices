﻿using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.Caching;
using CatalogApiReading.Infrastructure.Data.Caching.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.Category;
using CatalogApiReading.Infrastructure.Data.CategoryProduct;
using CatalogApiReading.Infrastructure.Data.Product;
using CatalogApiReading.Infrastructure.Data.UoW;
using CatalogApiReading.IntegrationEvent.EventHandling.Category;
using CatalogApiReading.IntegrationEvent.EventHandling.Product;
using CatalogApiReading.IntegrationEvent.Events.Category;
using CatalogApiReading.IntegrationEvent.Events.Product;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using GeekManiaMicroservices.Broker.EventBusRabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using StackExchange.Redis;

namespace CatalogApiReading.Infrastructure.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddSingleton<ICatalogDatabaseSettings>(sp => sp.GetRequiredService<IOptions<CatalogDatabaseSettings>>().Value)
                .AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>()
                .AddScoped<ICatalogContext, CatalogContext>()
                .AddScoped<ICatalogRedisContext, CatalogRedisContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IProductRedisRepository, ProductRedisRepository>()
                .AddScoped<ICategoryRedisRepository, CategoryRedisRepository>()
                .AddScoped<ICategoryProductRepository, CategoryProductRepository>()
                .AddScoped<ICategoryProductRedisRepository, CategoryProductRedisRepository>()
                .AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                {
                    var subscriptionClientName = Configuration["SubscriptionClientName"];
                    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                    }

                    return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, scopeFactory, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                })
                .AddSingleton<IRabbitMQPersistentConnection>(sp =>
                {
                    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                    var factory = new ConnectionFactory()
                    {
                        HostName = Configuration["EventBusConnection"],
#if DEBUG
                        Port = int.Parse(Configuration["EventBusPort"]),
#endif
                        DispatchConsumersAsync = true
                       
                    };
                                        

                    if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                    {
                        factory.UserName = Configuration["EventBusUserName"];
                    }

                    if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                    {
                        factory.Password = Configuration["EventBusPassword"];
                    }

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                    }

                    return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                })
                .AddTransient<ProductCreateEventHandler>()
                .AddTransient<IEventHandler<ProductCreateEvent>, ProductCreateEventHandler>()
                .AddTransient<ProductUpdateEventHandler>()
                .AddTransient<IEventHandler<ProductUpdateEvent>, ProductUpdateEventHandler>()
                .AddTransient<CategoryCreateEventHandler>()
                .AddTransient<IEventHandler<CategoryCreateEvent>, CategoryCreateEventHandler>()
                .AddTransient<CategoryUpdateEventHandler>()
                .AddTransient<IEventHandler<CategoryUpdateEvent>, CategoryUpdateEventHandler>()
                .AddSingleton<ConnectionMultiplexer>(sp =>
                {
                    var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("RedisConnection"), true);
                    return ConnectionMultiplexer.Connect(configuration);
                });

            //.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Configuration.GetConnectionString("RedisConnection");
            //    options.InstanceName = "GeekMania:";
            //});


            return services;
        }
    }
}
