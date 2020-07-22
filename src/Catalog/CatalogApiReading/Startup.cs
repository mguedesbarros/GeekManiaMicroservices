using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.Product;
using CatalogApiReading.Infrastructure.IoC;
using CatalogApiReading.IntegrationEvent.EventHandling;
using CatalogApiReading.IntegrationEvent.Events;
using CatalogApiReading.Models;
using GeekManiaMicroservices.Broker.EventBus;
using GeekManiaMicroservices.Broker.EventBus.Abstractions;
using GeekManiaMicroservices.Broker.EventBusRabbitMQ;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;

namespace CatalogApiReading
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //options.F.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.Configure<CatalogDatabaseSettings>(Configuration.GetSection(nameof(CatalogDatabaseSettings)));

            //IoC
            services.AddDependencies(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Api GeekManiaCatalogReading",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core 3.1 para GeekMania",
                        Contact = new OpenApiContact
                        {
                            Name = "Marcelo Guedes"
                            //Url = new Uri("")
                        }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Gera o endpoint que retornará os dados utilizados no dashboard
            //app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});

            //// Ativa o dashboard para a visualização da situação de cada Health Check
            //app.UseHealthChecksUI();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api de GeekManiaCatalogReading V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<ProductCreateEvent, ProductCreateEventHandler>();
            eventBus.Subscribe<CategoryCreateEvent, CategoryCreateEventHandler>();
        }
    }
}
