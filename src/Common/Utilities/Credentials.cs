namespace DEA.Common.Utilities
{
    public partial class Credentials
    {
        public string Token { get; set; }

        public ulong[] OwnerIds { get; set; }

        public string YoutubeApi{ get; set; } 

        public int ShardCount { get; set; } = 1;

        public string MongoDBConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; }
    }
}
