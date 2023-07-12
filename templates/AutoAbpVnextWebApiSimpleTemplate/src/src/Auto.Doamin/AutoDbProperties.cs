namespace Auto.Doamin
{
    public static class AutoDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; }

        public const string ConnectionStringName = "Auto";
    }
}