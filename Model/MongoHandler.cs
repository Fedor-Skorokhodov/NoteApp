using MongoDB.Driver;

namespace NoteApp.Model
{
    internal class MongoHandler
    {
        private static MongoHandler? _instance;
        private static MongoClient? _client;
        private static IMongoDatabase? _db;

        private MongoHandler() {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("note_app_db");
        }

        public static MongoHandler getInstance()
        {
            _instance ??= new MongoHandler();
            return _instance;
        }

        public IMongoDatabase GetDatabase() 
        {
            return _db;
        }
    }
}
