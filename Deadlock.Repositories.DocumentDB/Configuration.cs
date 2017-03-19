namespace Deadlock.Repositories.DocumentDB
{
    public class Configuration : IConfiguration
    {
        public string EndpointUrl { get; set; }

        public string DataBaseName { get; set; }

        public string CollectionDefault { get; set; }

        public string AuthorizationKey { get; set; }

        public string PrefixDocType { get; set; }
    }
}
