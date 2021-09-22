using Microsoft.Extensions.DependencyInjection;
using ModuleBuilder;
using Organisations.Core;
using StackExchange.Redis;

namespace Organisations.Api.Graphql
{
    public static class FeatureConfigurationExtensions
    {
        public static PluginConfigurationBuilder<OrganisationsModuleDefinition> AddGraphQlEndpoints(
            this PluginConfigurationBuilder<OrganisationsModuleDefinition> builder,
            string redisConnectionString, string configurationName = "graphql", string schema = null)
        {
            builder.Services
                .AddSingleton(ConnectionMultiplexer.Connect(redisConnectionString));
            
            schema ??= builder.GetModuleName;
            
            builder.Services.AddMiniProfiler(options => { options.RouteBasePath = $"{schema}/profiler"; });

            builder.Services.AddGraphQLServer(schema)
                .MapOrganisationQueries()
                .InitializeOnStartup()
                .PublishSchemaDefinition(c => c
                    .SetName(schema)
                    .PublishToRedis(configurationName,
                        sp => sp.GetRequiredService<ConnectionMultiplexer>())
                )
                .ModifyOptions(x => x.RemoveUnreachableTypes = true);;

            return builder;
        }
    }
}