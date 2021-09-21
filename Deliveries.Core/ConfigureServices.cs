using System;
using Deliveries.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using ModuleBuilder;

namespace Deliveries.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDeliveriesServices(this IServiceCollection serviceCollection, Action<PluginConfigurationBuilder<DeliveriesModuleDefinition>> configure)
        {
            var config = new PluginConfigurationBuilder<DeliveriesModuleDefinition>(serviceCollection);
            configure(config);
            
            serviceCollection.AddSingleton<DeliveriesRepository>();

            return config.Services;
        }
    }
}