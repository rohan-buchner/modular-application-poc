using Deliveries.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModuleBuilder;

namespace Deliveries.Database.NpgSql
{
    public static class PluginConfigurationExtensions
    {
        public static PluginConfigurationBuilder<DeliveriesModuleDefinition> UseNpgSql(this PluginConfigurationBuilder<DeliveriesModuleDefinition> builder,
            string connectionString, bool enableDetailedErrors = false, bool enableSensitiveDataLogging = false)
        {
            builder.Services.AddPooledDbContextFactory<DeliveriesDbContext>(opt =>
                {
                    opt.UseNpgsql(connectionString);
                    if (enableDetailedErrors)
                        opt.EnableDetailedErrors();
                    if (enableSensitiveDataLogging)
                        opt.EnableSensitiveDataLogging();
                }
            );

            return builder;
        }
    }
}