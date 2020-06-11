using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using CatalogApi.Messaging.Options;
using CatalogApi.Infrastructure.IoC;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CatalogApi
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //options.F.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            //.AddJsonOptions(p => {
            //     p.SerializerSettings.ContractResolver = new DefaultContractResolver()
            //     {
            //         NamingStrategy = new SnakeCaseNamingStrategy()
            //     };
            //     p.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            // }); ;

            services.AddHealthChecks();

            services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMq"));
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as ActionExecutingContext;

                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });

            services.AddDependencies();

            //AddDependencies(services);
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<ICategoryUpdateSender, CategoryUpdateSender>();
            //services.AddDbContext<CatalogContext>();
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
            app.UseHealthChecks("/hc");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        
    }
}
