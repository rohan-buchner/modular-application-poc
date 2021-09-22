namespace Testbed.Common
{
    public static class Constants
    {
        public static string ApplicationUrl => "https://localhost:5051/";
        public static string GatewayUrl => "https://localhost:5052/";
 
        public static string SqlKey => "sql";
        public static string RedisKey => "redis";
        public static string MongoKey => "mongodb";

        public static DomainConfigItem Deliveries => new DomainConfigItem(ApplicationUrl, "deliveries");
        public static DomainConfigItem Organisations => new DomainConfigItem(ApplicationUrl, "organisations");
        
        public static string RedisConfigurationName => "testbed_schema";
        public static string TestbedSchema => "testbed";
    }

    public class DomainConfigItem
    {
        public DomainConfigItem(string applicationUrl, string schema)
        {
            Schema = schema;
            Url = $"{applicationUrl}{schema}";
            Path = $"/{schema}";
            Schema = schema;
        }

        public string Url { get; }
        public string Path { get; }
        public string Schema { get; }
    }
}