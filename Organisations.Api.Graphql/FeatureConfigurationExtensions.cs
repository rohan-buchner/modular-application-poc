using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrderIn.NetCore.Graphql.Debugging;
using OrderIn.NetCore.PluginBuilder;
using Organisation;
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

            builder.Services.AddMiniProfiler(options => { options.RouteBasePath = "/profiler"; });

            schema ??= builder.GetModuleName;

            builder.Services.AddGraphQLServer(schema)
                .MapOrganisationQueries()
                .AddDiagnosticEventListener(sp =>
                    new ConsoleQueryLogger(sp.GetService<ILogger<ConsoleQueryLogger>>()))
                .InitializeOnStartup()
                .PublishSchemaDefinition(c => c
                    .SetName(schema)
                    .PublishToRedis(configurationName,
                        sp => sp.GetRequiredService<ConnectionMultiplexer>())
                );

            return builder;
        }
    }
}