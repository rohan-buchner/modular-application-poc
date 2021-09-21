using Microsoft.Extensions.DependencyInjection;
using OrderIn.NetCore.PluginBuilder;
using Organisations.Core;

namespace Organisations.Database.Mongodb
{
    public static class PluginConfigurationExtensions
    {
        public static PluginConfigurationBuilder<OrganisationsModuleDefinition> UseMongoDb(this PluginConfigurationBuilder<OrganisationsModuleDefinition> builder,
            string connectionString, bool enableDebugging = false)
        {
            builder.Services.AddOptions<MongoOptions>()
                .Configure(mongoOptions =>
                {
                    mongoOptions.Database = builder.GetModuleName;
                    mongoOptions.ConnectionString = connectionString;
                    mongoOptions.EnableDebugging = enableDebugging;
                });

            builder.Services.AddSingleton<OrderinOrganisationsDbContext>();

            return builder;
        }
    }
}