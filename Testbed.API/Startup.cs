using Deliveries.Api.Graphql;
using Deliveries.Core;
using Deliveries.Database.NpgSql;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organisations.Api.Graphql;
using Organisations.Api.Mongodb;
using Organisations.Core;
using Testbed.Common;

namespace Testbed.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDeliveriesServices(builder =>
            {
                builder
                    .UseNpgSql(_config.GetConnectionString(Constants.SqlKey))
                    .AddGraphQlEndpoints(_config.GetConnectionString(Constants.RedisKey),
                        Constants.RedisConfigurationName);
            });

            services.AddOrganisationServices(builder =>
            {
                builder
                    .UseMongoDb(_config.GetConnectionString(Constants.MongoKey))
                    .AddGraphQlEndpoints(_config.GetConnectionString(Constants.RedisKey),
                        Constants.RedisConfigurationName);
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseVoyager();
            app.UsePlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDeliveriesEndpoint(Constants.Deliveries.Path);
                endpoints.MapOrganisationsEndpoint(Constants.Organisations.Path);
            });
        }
    }
}