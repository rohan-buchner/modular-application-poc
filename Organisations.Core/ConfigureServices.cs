using System;
using Microsoft.Extensions.DependencyInjection;
using OrderIn.NetCore.PluginBuilder;
using Organisation.Domain;

namespace Organisation
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddOrderinOrganisationServices(this IServiceCollection serviceCollection, Action<PluginConfigurationBuilder<OrganisationsModuleDefinition>> configure)
        {
            var config = new PluginConfigurationBuilder<OrganisationsModuleDefinition>(serviceCollection);
            configure(config);

            serviceCollection.AddSingleton<CompanyRepository>();
            serviceCollection.AddSingleton<UserRepository>();

            serviceCollection.AddCap(options =>
            {
                options.UseDashboard();
                options.UseInMemoryStorage();
                options.UseRabbitMQ("localhost");
            });
            
            return config.Services;
        }
    }
}