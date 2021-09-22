using System;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Testbed.Common;

namespace Testbed.Gateway
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(Constants.Deliveries.Schema, c => c.BaseAddress = new Uri(Constants.Deliveries.Url));
            services.AddHttpClient(Constants.Organisations.Schema, c => c.BaseAddress = new Uri(Constants.Organisations.Url));
            services.AddSingleton(ConnectionMultiplexer.Connect(_configuration.GetConnectionString(Constants.RedisKey)));

            services
                .AddGraphQLServer()
                .AddRemoteSchemasFromRedis(Constants.RedisConfigurationName, sp => sp.GetRequiredService<ConnectionMultiplexer>())
                .ModifyOptions(x => x.RemoveUnreachableTypes = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseVoyager();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}