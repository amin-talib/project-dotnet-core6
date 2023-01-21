using Food.Menu.Service.Entities;
using Food.Menu.Service.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Food.Menu.Service.Repositories
{
    public static class Extensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
              BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
           BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            

            services.AddSingleton(serviceProvider => {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var cartDbSettings = configuration.GetSection(nameof(CartDbSettings)).Get<CartDbSettings>();
                var mongoClient = new MongoClient(cartDbSettings.ConnectionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });
            return services;
        }
        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services,string collectionName)where T : IEntity
        {
                services.AddSingleton<IRepository<Menus>>(serviceProvider => 
            {
                var database = serviceProvider.GetService<IMongoDatabase>();
                return new MenusRepository<Menus>(database,collectionName);
            });
            return services;
        }
    }
}