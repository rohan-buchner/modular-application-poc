using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Deliveries.Database.NpgSql
{
    public class NpgSqlContextFactory<T> : IDesignTimeDbContextFactory<T>
        where T : DbContext
    {
        public T CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var config = configurationBuilder
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var connectionString = config.GetConnectionString("Sql");
            
            var optionsBuilder = new DbContextOptionsBuilder<T>();

            optionsBuilder.UseNpgsql(connectionString);
            return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
        }
    }
}