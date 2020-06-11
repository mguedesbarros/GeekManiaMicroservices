using CatalogApi.Application.Services;
using CatalogApi.Application.Services.Interfaces;
using CatalogApi.Domain.Aggregates.Events;
using CatalogApi.Domain.Aggregates.Events.Handler;
using CatalogApi.Domain.Repositories;
using CatalogApi.Domain.SeedWork;
using CatalogApi.Infrastructure.Data;
using CatalogApi.Infrastructure.Data.Repositories;
using CatalogApi.Infrastructure.EventBus;
using CatalogApi.Infrastructure.Mapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            services
               .AddSingleton<ITypeAdapterFactory, AutoMapperTypeAdapterFactory>()
               .AddSingleton<ITypeAdapter, AutoMapperTypeAdapter>()
               .AddSingleton<IEventBus, RabbitEventBus>()
               .AddTransient<IRabbitConnection, RabbitConnection>()
               .AddScoped<IUnitOfWork, UnitOfWork>()
               .AddDbContext<CatalogContext>()
               .AddTransient<ICategoryRepository, CategoryRepository>()
               .AddTransient<ICategoryAppService, CategoryAppService>()
               .AddScoped<INotificationHandler<CreateCategoryEvent>, CategoryEventHandler>()
               .AddScoped<INotificationHandler<UpdateCategoryEvent>, CategoryEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();


            services.AddMediatR(typeof(Entity));

            var sp = services.BuildServiceProvider();

            TypeAdapterFactory.SetCurrent(sp.GetService<ITypeAdapterFactory>());

            return services;
        }
    }
}
