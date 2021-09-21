using Deliveries.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrderIn.NetCore.Graphql.Debugging;
using OrderIn.NetCore.PluginBuilder;
using StackExchange.Redis;

namespace Deliveries.Api.Graphql
{
    public static class FeatureConfigurationExtensions
    {
        public static PluginConfigurationBuilder<DeliveriesModuleDefinition> AddGraphQlEndpoints(this PluginConfigurationBuilder<DeliveriesModuleDefinition> builder,
            string redisConnectionString, string configurationName = "graphql", string schema = null)
        {
            builder.Services
                .AddSingleton(ConnectionMultiplexer.Connect(redisConnectionString));
            
            builder.Services.AddMiniProfiler(options => { options.RouteBasePath = "/profiler"; });

            schema ??= new DeliveriesModuleDefinition().ModuleName;
            
            builder.Services.AddGraphQLServer(schema)
                .MapDeliveriesQueries()
                .AddDiagnosticEventListener(sp =>
                    new ConsoleQueryLogger(sp.GetService<ILogger<ConsoleQueryLogger>>()))
                .InitializeOnStartup()
                .PublishSchemaDefinition(c => c
                    .SetName(schema)
                    .PublishToRedis(configurationName, sp => sp.GetRequiredService<ConnectionMultiplexer>())
                );

            return builder;
        }
    }
}