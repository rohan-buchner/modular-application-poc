using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using Organisations.Core.Domain;

namespace Organisations.Api.Mongodb
{
    public class MongoOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool EnableDebugging { get; set; }
    }

    public class OrganisationsDbContext
    {
        private readonly IMongoDatabase _database;

        public OrganisationsDbContext(ILogger<OrganisationsDbContext> logger, IOptions<MongoOptions> options)
        {
            var mongoConnectionUrl = new MongoUrl(options.Value.ConnectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);

            if (options.Value.EnableDebugging)
                mongoClientSettings.ClusterConfigurator = cb =>
                {
                    // This will print the executed command to the console
                    cb.Subscribe<CommandStartedEvent>(e =>
                    {
                        logger.LogDebug($"{e.CommandName} - {e.Command.ToJson()}");
                    });
                };
            
            var client = new MongoClient(mongoClientSettings);
            if (client != null)
                _database = client.GetDatabase(options.Value.Database ?? "Organisations");
        }

        public IMongoCollection<Company> Countries
        {
            get { return _database.GetCollection<Company>("Companies"); }
        }

        public IMongoCollection<User> ConversionRates
        {
            get { return _database.GetCollection<User>("Users"); }
        }
    }
}