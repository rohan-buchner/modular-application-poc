using Deliveries.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModuleBuilder;
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

            schema ??= new DeliveriesModuleDefinition().ModuleName;

            builder.Services.AddMiniProfiler(options => { options.RouteBasePath = $"{schema}/profiler"; });
            
            builder.Services.AddGraphQLServer(schema)
                .MapDeliveriesQueries()
                .InitializeOnStartup()
                .PublishSchemaDefinition(c => c
                    .SetName(schema)
                    .PublishToRedis(configurationName, sp => sp.GetRequiredService<ConnectionMultiplexer>())
                )
                .ModifyOptions(x => x.RemoveUnreachableTypes = true);;

            return builder;
        }
    }
}