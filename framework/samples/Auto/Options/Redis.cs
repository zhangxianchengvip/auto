using Auto.Core.Options;

namespace Auto.Options
{
    [AutoOptions(Node ="Redis")]
    public class Redis
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }

}
