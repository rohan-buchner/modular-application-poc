using Microsoft.Extensions.DependencyInjection;

namespace ModuleBuilder
{
    public class PluginConfigurationBuilder<T> where T: ModuleDefinition, new()
    {
        public PluginConfigurationBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public string GetModuleName => new T().ModuleName.ToLower();

        public readonly IServiceCollection Services;
    }
}