using System;
using ConnectApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;
using Pagination;
using Sorting;
using ConnectApi.Filters;

namespace ConnectApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConnectDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddEntityFrameworkSqlite().AddDbContext<ConnectDbContext>();

            // Add framework services.
            services.AddMvcCore(o =>
                {
                    o.Filters.Add(typeof(PaginationFilter));
                    o.Filters.Add(typeof(SortingFilter));
                    o.Filters.Add(typeof(ExceptionHandlerFilter));
                })
                .AddApiExplorer()
                .AddDataAnnotations()
                .AddJsonFormatters(json =>
                {
                    json.ContractResolver = new DefaultContractResolver();
                    json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSwaggerGen(c => { c.SwaggerDoc("docs", new Info {Title = "Connect Api", Version = "v1"}); });

            // StructureMap Configuration [This must be at the end]         
            var builder = new Container();
            builder.Configure(config =>
            {
                config.Scan(
                    scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                        scan.LookForRegistries();
                    });
                config.Populate(services);
            });

            var sevice = builder.GetInstance<IServiceProvider>();
            return sevice;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            ConnectDbContext connectDbContext)
        {
            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "{documentName}/swagger.json"; });
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/docs/swagger.json", "Connect Api"); });

            connectDbContext.Database.EnsureDeleted();
            connectDbContext.Database.EnsureCreated();

            SeedData.SeedData.Initialize(connectDbContext);
        }
    }
}