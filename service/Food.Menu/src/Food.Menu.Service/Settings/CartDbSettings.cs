namespace Food.Menu.Service.Settings
{
    public class CartDbSettings
    {
        public string Host { get; init; }
         public int Port { get; init; }

        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}