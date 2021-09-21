namespace Testbed
{
    public static class Constants
    {
        public static string ApplicationUrl => "https://localhost:5051/";
 
        public static string SqlKey => "sql";
        public static string RedisKey => "redis";
        public static string MongoKey => "mongodb";
         
        public static string RedisConfigurationName => "testbed_schema";
         
        public static string DeliveriesSchema => "deliveries";
        public static string OrganisationsSchema => "organisations";
        public static string TestbedSchema => "testbed";
    }
}