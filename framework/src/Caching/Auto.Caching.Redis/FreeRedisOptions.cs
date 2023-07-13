using Auto.Core.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Caching.Redis
{
    [AutoOptions(Node = "RedisOptions")]
    public class FreeRedisOptions
    {
        private const string DefaultHost = "localhost";
        private const int DefaultPort = 6379;
        public string Host { get; set; } = DefaultHost;
        public int Port { get; set; } = DefaultPort;
        public int Database { get; set; }
    }
}
