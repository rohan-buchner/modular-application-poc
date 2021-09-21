using System;
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
using StackExchange.Redis;

namespace Testbed
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
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDeliveriesServices(builder =>
            {
                builder
                    .UseNpgSql(_config.GetConnectionString(Constants.SqlKey))
                    .AddGraphQlEndpoints(_config.GetConnectionString(Constants.RedisKey),
                        Constants.RedisConfigurationName, Constants.DeliveriesSchema);
            });

            services.AddOrganisationServices(builder =>
            {
                builder
                    .UseMongoDb(_config.GetConnectionString(Constants.MongoKey))
                    .AddGraphQlEndpoints(_config.GetConnectionString(Constants.RedisKey),
                        Constants.RedisConfigurationName, Constants.OrganisationsSchema);
            });

            services.AddHttpClient(Constants.DeliveriesSchema, 
                c => c.BaseAddress = new Uri($"{Constants.ApplicationUrl}/{Constants.DeliveriesSchema}"));
            
            services.AddHttpClient(Constants.OrganisationsSchema,
                c => c.BaseAddress = new Uri($"{Constants.ApplicationUrl}/{Constants.OrganisationsSchema}"));
            
            services.AddSingleton(ConnectionMultiplexer.Connect(_config.GetConnectionString(Constants.RedisKey)));

            services
                .AddGraphQLServer(Constants.TestbedSchema)
                .ModifyOptions(opt =>
                {
                    opt.StrictValidation = false;
                })
                .AddRemoteSchemasFromRedis(Constants.RedisConfigurationName, sp => sp.GetRequiredService<ConnectionMultiplexer>())
                .AddTypeRewriter(new RenameTypeRewriter())
                .ModifyOptions(x => x.RemoveUnreachableTypes = true);
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
                endpoints.MapDeliveriesEndpoint($"/{Constants.DeliveriesSchema}", Constants.DeliveriesSchema);
                endpoints.MapOrganisationsEndpoint($"/{Constants.OrganisationsSchema}", Constants.OrganisationsSchema);
                
                endpoints.MapGraphQL("/graphql", Constants.TestbedSchema);
            });
        }
    }
}