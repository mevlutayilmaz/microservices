using MongoDB.Driver;

namespace Example.Stock.API.Services
{
    public class MongoDBService
    {
        readonly IMongoDatabase _database;
        public MongoDBService(IConfiguration configuration)
        {
            MongoClient client = new(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("ExampleStockDb");
        }

        public IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name.ToLowerInvariant()); 
    }
}
