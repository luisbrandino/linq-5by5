using MongoDB.Driver;

namespace aula02
{
    public class MongoRepository<T>
    {
        private readonly string CONNECTION_STRING = "mongodb://root:Mongo%402024%23@localhost:27017/";

        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        public MongoRepository(string databaseName, string collectionName)
        {
            _client = new MongoClient(CONNECTION_STRING);
            _database = _client.GetDatabase(databaseName);
            _collection = _database.GetCollection<T>(collectionName);
        }

        public void InsertMany(List<T> entities) => _collection.InsertMany(entities);
    }
}
