using CatalogApi.Domain.Entities;
using CatalogApi.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Infrastructure.Data
{
    public class CatalogContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory 
            = LoggerFactory.Create(builder => 
            {
                //builder.AddFilter((category, level) => 
                //    category == DbLoggerCategory.Database.Command.Name &&
                //    level == LogLevel.Trace)
                //.AddConsole(); 
                builder.AddConsole().AddDebug();
            });        

        public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
        {
        }

        private DbConnection connection;
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var cnn = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(cnn)
                .EnableDetailedErrors()
                .UseLoggerFactory(_loggerFactory);

            this.connection = new MySqlConnection(cnn);            

            //#if DEBUG
            //            optionsBuilder.UseMySql("Server=167.99.99.251;Port=3333;Database=geekmania;Uid=root;Pwd=geekmania!202@");
            //#else
            //            optionsBuilder.UseMySql("Server=geekmania-db;Port=3306;Database=geekmania;Uid=root;Pwd=geekmania!202@");
            //#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        public DbConnection GetConnection() => this.connection;
    }
}
